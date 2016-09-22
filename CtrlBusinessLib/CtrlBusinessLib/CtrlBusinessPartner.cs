using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudApiLib;
using CloudApiLib.Documents;
using MongoDB.Bson;

namespace CtrlBusinessLib
{
    public class CtrlBusinessPartner : CADocument<CtrlBusinessPartner>
    {
        static CtrlBusinessPartner()
        {
            CloudApi.RegisterObjectType<CtrlBusinessPartner>();
        }

        public string BusinessPartnerId { get; set; }

        public string Name1 { get; set; }
        public string Name2 { get; set; }
        public string Name3 { get; set; }
        public string Name4 { get; set; }
        
        public CtrlCountry Country { get; set; }
        public string State { get; set; }
        public string CityCode { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
    }
}
