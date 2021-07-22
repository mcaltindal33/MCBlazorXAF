using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;

using System;

namespace MC.Module.BaseObjects
{
    [NonPersistent, MemberDesignTimeVisibility(false)]
    public abstract class MCLongObject : XPCustomObject
    {

        public MCLongObject() { }

        public MCLongObject(Session session) : base(session) { }

        public MCLongObject(Session session, XPClassInfo classInfo) : base(session, classInfo) { }
        Int64 _Mid = 0;

        [Persistent(nameof(Mid)), Key(true), DisplayName("ID"), VisibleInListView(false), VisibleInDetailView(false), VisibleInLookupListView(false)]
        public Int64 Mid
        {
            get { return _Mid; }
            set
            {
                Int64 eskiMid = Mid;
                if (eskiMid == value)
                    return;
                _Mid = value;
                OnChanged(nameof(Mid), eskiMid, value);
            }
        }
    }
}
