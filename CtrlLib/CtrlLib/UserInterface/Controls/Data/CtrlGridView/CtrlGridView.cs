using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CtrlLib.Helper;

namespace CtrlLib.UserInterface.Controls.Data.CtrlGridView
{
    public class CtrlGridView : ListView
    {
        public ICollectionView ResultsFilterView { get; set; }

        private Dictionary<string, string> _columnFilters;
        private Dictionary<string, PropertyInfo> _propertyCache;

        public delegate void CtrlOnRowDoubleClick(object sender, MouseButtonEventArgs args);
        public event CtrlOnRowDoubleClick CtrlRowDoubleClick;

        static CtrlGridView()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CtrlGridView), new FrameworkPropertyMetadata(typeof(CtrlGridView)));
        }

        public CtrlGridView()
        {
            View = new GridView();
            AddHandler(TextBoxBase.TextChangedEvent, new TextChangedEventHandler(FilterTextBox_OnTextChanged));

            _columnFilters = new Dictionary<string, string>();
            _propertyCache = new Dictionary<string, PropertyInfo>();

            DataContextChanged += new
              DependencyPropertyChangedEventHandler(
              CtrlGridView_OnDataContextChanged);

            RegisterCustomEvents();
        }

        private void CtrlGridView_OnDataContextChanged(object sender, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
            _propertyCache.Clear();
        }

        private void FilterTextBox_OnTextChanged(object sender, TextChangedEventArgs textChangedEventArgs)
        {
            var filterTextBox = textChangedEventArgs.OriginalSource as TextBox;

            var header =
              CtrlUiHelper.FindAncestor<GridViewColumnHeader>(filterTextBox);
            if (header != null)
            {
                CtrlUpdateFilter(filterTextBox, header);
                CtrlApplyFilters();
            }
        }

        private void CtrlUpdateFilter(TextBox textBox, GridViewColumnHeader iHeader)
        {
            // Try to get the property bound to the column.
            // This should be stored as datacontext.
            if (iHeader.Column == null)
                return;

            var columnBinding = iHeader.Column.DisplayMemberBinding != null ?
                                        ((Binding)iHeader.Column.DisplayMemberBinding).Path.Path : "";

            if (!string.IsNullOrEmpty(columnBinding))
                _columnFilters[columnBinding] = textBox.Text;
        }

        private void CtrlApplyFilters()
        {
            // Get the view
            ICollectionView view = CollectionViewSource.GetDefaultView(ItemsSource);
            if (view != null)
            {
                // Create a filter
                view.Filter = delegate (object item)
                {
                    // Show the current object
                    bool show = true;
                    // Loop filters
                    foreach (KeyValuePair<string, string> filter in _columnFilters)
                    {
                        object property = GetPropertyValue(item, filter.Key) != null ? GetPropertyValue(item, filter.Key) : string.Empty;
                        bool containsFilter = property.ToString().ToLower().Contains(filter.Value.ToLower());

                        // Do the necessary things if the filter is not correct
                        if (!containsFilter)
                        {
                            show = false;
                            break;
                        }
                    }
                    // Return if it's visible or not
                    return show;
                };
            }
        }

        private object GetPropertyValue(object item, string property)
        {
            // No value
            object value = null;
            // Get property  from cache
            PropertyInfo pi = null;
            if (_propertyCache.ContainsKey(property))
                pi = _propertyCache[property];
            else
            {
                pi = item.GetType().GetProperty(property);
                _propertyCache.Add(property, pi);
            }
            // If we have a valid property, get the value
            if (pi != null)
                value = pi.GetValue(item, null);
            // Done
            return value;
        }

        private void RegisterCustomEvents()
        {
            MouseDoubleClick += OnMouseDoubleClick;
        }

        private void OnMouseDoubleClick(object sender, MouseButtonEventArgs mouseButtonEventArgs)
        {
            var dep = (DependencyObject)mouseButtonEventArgs.OriginalSource;

            while ((dep != null) && !(dep is ListViewItem))
            {
                dep = VisualTreeHelper.GetParent(dep);
            }

            if (dep == null)
                return;

            var item = ItemContainerGenerator.ItemFromContainer(dep);
            if (CtrlRowDoubleClick != null)
            {
                CtrlRowDoubleClick(item, mouseButtonEventArgs);
            }

        }
    }
}
