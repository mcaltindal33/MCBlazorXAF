using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;

using System;

namespace MC.Module.BaseObjects
{
    [NonPersistent, MemberDesignTimeVisibility(false)]
    public abstract class MCObject : XPCustomObject
    {
        public MCObject() { }

        public MCObject(Session session) : base(session) { }

        public MCObject(Session session, XPClassInfo classInfo) : base(session, classInfo) { }

        Int32 _Mid = 0;

        [Persistent(nameof(Mid)), Key(true), DisplayName("ID"), VisibleInListView(false), VisibleInDetailView(false), VisibleInLookupListView(false)]
        public Int32 Mid
        {
            get { return _Mid; }
            set
            {
                Int32 eskiMid = Mid;
                if (eskiMid == value)
                    return;
                _Mid = value;
                OnChanged(nameof(Mid), eskiMid, value);
            }
        }
    }
}
