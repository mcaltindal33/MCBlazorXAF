using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;

using System;

namespace MC.Module.BaseObjects
{
    [NonPersistent, MemberDesignTimeVisibility(true)]
    public abstract class BaseTipler : MCByteObjectLite
    {
        protected BaseTipler()
        {
        }

        protected BaseTipler(Session session) : base(session)
        {
        }

        protected BaseTipler(Session session, XPClassInfo classInfo) : base(session, classInfo)
        {
        }


        string _Tanim;
        string _Kodu;

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        [Persistent("Code")]
        [Index(1)]
        public string Kodu
        {
            get => _Kodu;
            set => SetPropertyValue(nameof(Kodu), ref _Kodu, value);
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        [Persistent("Name")]
        [Index(2)]
        public string Tanim
        {
            get => _Tanim;
            set => SetPropertyValue(nameof(Tanim), ref _Tanim, value);
        }
    }
}
