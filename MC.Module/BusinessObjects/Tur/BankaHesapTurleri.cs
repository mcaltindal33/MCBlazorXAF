using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

using MC.Module.BaseObjects;

using System;
using System.ComponentModel;
using System.Linq;

namespace MC.Module.BusinessObjects.Tur
{
    [DefaultClassOptions]
    [DefaultProperty(nameof(Tanim))]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    [Persistent("BankAccountTypes")]
    public class BankaHesapTurleri : BaseTipler
    {
        public BankaHesapTurleri(Session session) : base(session) { }
    }
}