using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;

using System;

namespace MC.Module.BaseObjects
{
    [NonPersistent, MemberDesignTimeVisibility(true)]
    public abstract class BaseTurler : MCObjectLite
    {
        protected BaseTurler()
        {
        }

        protected BaseTurler(Session session) : base(session)
        {
        }

        protected BaseTurler(Session session, XPClassInfo classInfo) : base(session, classInfo)
        {
        }


        string _Aciklama;
        string _Tanim;
        string _Kodu;

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        [Persistent("Code")]
        [Index(0)]
        public string Kodu
        {
            get => _Kodu;
            set => SetPropertyValue(nameof(Kodu), ref _Kodu, value);
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        [Persistent("Name")]
        [Index(1)]
        public string Tanim
        {
            get => _Tanim;
            set => SetPropertyValue(nameof(Tanim), ref _Tanim, value);
        }

        
        [Size(SizeAttribute.Unlimited)]
        [Persistent("Description")]
        [Index(2)]
        public string Aciklama
        {
            get => _Aciklama;
            set => SetPropertyValue(nameof(Aciklama), ref _Aciklama, value);
        }

    }
}
