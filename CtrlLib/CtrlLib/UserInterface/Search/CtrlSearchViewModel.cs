using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Threading;
using CloudApiLib;
using CtrlLib.UserInterface.Controls.Data.CtrlGridView;
using CtrlLib.UserInterface.Mvvm;
using MongoDB.Bson;

namespace CtrlLib.UserInterface.Search
{
    public class CtrlSearchViewModel : CtrlBaseViewModel
    {
        public CtrlSearch CtrlSearchParam { get; set; }

        private object _searchResults;

        public object SearchResults
        {
            get { return _searchResults; }
            set
            {
                if (_searchResults != value)
                {
                    _searchResults = value;
                    OnPropertyChanged();
                }
            }
        }

        public CtrlDocumentPropName SearchDocumentInfo { get; set; }
        
        public override async void CtrlOnParametersPassed(Dictionary<string, object> iModuleParameters)
        {
            CtrlSearchParam = iModuleParameters["SEARCH_PARAM"] as CtrlSearch;
            SearchDocumentInfo = await CtrlDocumentPropName.FindOne(doc => doc.CtrlDocumentName == CtrlSearchParam.DocumentSearchType.Name);

            if(CtrlSearchParam.DocumentSearchType.GetProperty("IndexSearchString") == null)
                throw new Exception($"{CtrlSearchParam.DocumentSearchType.Name} does not support fulltext search. Please add IndexSearchString!");
            
            QueryFullTextSearch("");

            GenerateColumns();
        }

        public void QueryFullTextSearch(string iFilter)
        {
            var contains = typeof(string).GetMethod("Contains", new[] { typeof(string) });

            var paramExpression = Expression.Parameter(CtrlSearchParam.DocumentSearchType);
            var comparer = Expression.Property(paramExpression, "IndexSearchString");
            var comparerConst = Expression.Constant(iFilter, typeof(string));
            var containsExpr = Expression.Call(comparer, contains, comparerConst);

            var expressionTree = Expression.Lambda(containsExpr, paramExpression);

            var qryMethod = CtrlSearchParam.DocumentSearchType.BaseType.GetMethod("Find", BindingFlags.Public | BindingFlags.Static);
            var res = qryMethod.Invoke(null, new [] { expressionTree });

            var awaiter = res.GetType().GetMethod("GetAwaiter").Invoke(res, null);
            awaiter.GetType().GetMethod("OnCompleted").Invoke(awaiter, new object[]
            {
                new Action(() =>
                {
                    Dispatcher.CurrentDispatcher.Invoke(() =>
                    {
                        var constructedType = typeof(ObservableCollection<>).MakeGenericType(CtrlSearchParam.DocumentSearchType);
                        
                        var resultInfo = res.GetType().GetProperty("Result");
                        if (resultInfo == null) return;

                        var searchResult = resultInfo.GetValue(res);

                        ((CtrlSearchUserControl) CtrlUserControl).ResultsGridControl.ItemsSource = Convert.ChangeType(searchResult, constructedType) as ICollection;
                    });
                })
            });
        }

        public void GenerateColumns()
        {
            foreach (var prop in CtrlSearchParam.DocumentSearchType.GetProperties())
            {
                if (prop.PropertyType == typeof (ObjectId) ||
                    !SearchDocumentInfo.PropertyNameLabelMapping.ContainsKey(prop.Name))
                    continue;

                var columnHeader = SearchDocumentInfo.PropertyNameLabelMapping[prop.Name];

                object column = null;

                if (prop.PropertyType == typeof (string))
                {
                    column = new GridViewColumn
                    {
                        Header = columnHeader
                    };
                }

                if (column != null)
                {
                    var gvc = column as GridViewColumn;
                    gvc.DisplayMemberBinding = new Binding(prop.Name);
                    (((CtrlSearchUserControl)CtrlUserControl).ResultsGridControl.View as GridView).Columns.Add(gvc);
                }
            }
        }

        public void ReturnResult(object iResult)
        {
            CtrlSearchParam.ReturnResult(iResult);
        }
    }
}
