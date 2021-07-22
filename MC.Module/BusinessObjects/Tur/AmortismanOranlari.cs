using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Model;
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
    [Persistent("DepreciationRates")]
    public class AmortismanOranlari : BaseTurler
    {
        public AmortismanOranlari(Session session) : base(session) { }

        decimal _NormalAmortismanOrani;
        int _FaydaliOmur;

        [Persistent("UsefulLife")]
        public int FaydaliOmur
        {
            get => _FaydaliOmur;
            set => SetPropertyValue(nameof(FaydaliOmur), ref _FaydaliOmur, value);
        }

        [Persistent("NDR")]
        public decimal NormalAmortismanOrani
        {
            get => _NormalAmortismanOrani;
            set => SetPropertyValue(nameof(NormalAmortismanOrani), ref _NormalAmortismanOrani, value);
        }
    }
}