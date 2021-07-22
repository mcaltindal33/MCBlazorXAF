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
    [Persistent("BankBranches")]
    public class BankaSubeleri : BaseTurler
    {
        public BankaSubeleri(Session session) : base(session)
        { }


        string _SubeKodu;
        string _SWIFT;
        string _Adres;
        Bankalar _Banka;

        [Association("Bankalar-BankaSubeleris")]
        public Bankalar Banka
        {
            get => _Banka;
            set => SetPropertyValue(nameof(Banka), ref _Banka, value);
        }

        [Size(SizeAttribute.Unlimited)]
        [ModelDefault("RowCount", "0")]
        public string Adres
        {
            get => _Adres;
            set => SetPropertyValue(nameof(Adres), ref _Adres, value);
        }


        [Size(20)]
        public string SWIFT
        {
            get => _SWIFT;
            set => SetPropertyValue(nameof(SWIFT), ref _SWIFT, value);
        }


        [Size(20)]
        public string SubeKodu
        {
            get => _SubeKodu;
            set => SetPropertyValue(nameof(SubeKodu), ref _SubeKodu, value);
        }
    }
}