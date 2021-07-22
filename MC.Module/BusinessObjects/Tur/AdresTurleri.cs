using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;

using MC.Module.BaseObjects;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace MC.Module.BusinessObjects.Tur
{
    [DefaultClassOptions]
    [DefaultProperty(nameof(Tanim))]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    [Persistent("AddressTypes")]
    public class AdresTurleri : BaseTurler
    { 
        public AdresTurleri(Session session) : base(session) { }
    }
}