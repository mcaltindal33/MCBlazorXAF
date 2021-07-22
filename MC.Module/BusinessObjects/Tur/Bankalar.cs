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
    [Persistent("Banks")]
    public class Bankalar : BaseTurler
    {
        public Bankalar(Session session) : base(session) { }

        [Association("Bankalar-BankaSubeleris")]
        public XPCollection<BankaSubeleri> BankaSubeleris
        {
            get
            {
                return GetCollection<BankaSubeleri>(nameof(BankaSubeleris));
            }
        }
    }
}