using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;

using System;

namespace MC.Module.BaseObjects
{
    [NonPersistent, MemberDesignTimeVisibility(true)]
    public abstract class MCByteObject : XPCustomObject
    {
        public MCByteObject() { }

        public MCByteObject(Session session) : base(session) { }

        public MCByteObject(Session session, XPClassInfo classInfo) : base(session, classInfo) { }

        Byte _Mid = 0;

        [Persistent(nameof(Mid)), Key(false), DisplayName("ID"),VisibleInListView(false)]
        public Byte Mid
        {
            get { return _Mid; }
            set
            {
                Byte eskiMid = Mid;
                if (eskiMid == value)
                    return;
                _Mid = value;
                OnChanged(nameof(Mid), eskiMid, value);
            }
        }

    }
}
