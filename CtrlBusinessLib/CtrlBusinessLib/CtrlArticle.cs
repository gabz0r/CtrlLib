using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudApiLib;
using CloudApiLib.Documents;
using CloudApiLib.Triggers;

namespace CtrlBusinessLib
{
    public class CtrlArticle : CADocument<CtrlArticle>
    {
        static CtrlArticle()
        {
            CloudApi.RegisterObjectType<CtrlArticle>();
        }
        
        public string IndexSearchString { get; set; }

        public string ArticleId { get; set; }

        public string Description1 { get; set; }
        public string Description2 { get; set; }
        public string Description3 { get; set; }
        public string Description4 { get; set; }

        //Link to CtrlBusinessPartner.BusinessPartnerId
        public List<string> Suppliers { get; set; } 

        public decimal SellingPrice { get; set; }

        public decimal LastPurchasePrice { get; set; }
        public CtrlBusinessPartner LastSupplier { get; set; }

        public decimal CheapestPurchasePrice { get; set; }
        public CtrlBusinessPartner CheapestSupplier { get; set; }
        public DateTime CheapestPurchaseDate { get; set; }

        [CATrigger(CATriggerType.PreCreate, "CtrlArticle")]
        public CtrlArticle PreCreate(CtrlArticle iNewArticle)
        {
            BuildSearchString(iNewArticle);
            return iNewArticle;
        }

        [CATrigger(CATriggerType.PreUpdate, "CtrlArticle")]
        public CtrlArticle PreUpdate(CtrlArticle iOldArticle, CtrlArticle iNewArticle)
        {
            BuildSearchString(iNewArticle);
            return iNewArticle;
        }

        private void BuildSearchString(CtrlArticle iBaseArticle)
        {
            iBaseArticle.IndexSearchString =
                $"{iBaseArticle.ArticleId}|{iBaseArticle.Description1}|{iBaseArticle.Description2}|{iBaseArticle.Description3}|{iBaseArticle.Description4}";
        }
    }
}
