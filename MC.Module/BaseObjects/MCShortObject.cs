using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;

using System;

namespace MC.Module.BaseObjects
{
    [NonPersistent, MemberDesignTimeVisibility(true)]
    public abstract class MCShortObject : XPCustomObject
    {

        public MCShortObject() { }

        public MCShortObject(Session session) : base(session) { }

        public MCShortObject(Session session, XPClassInfo classInfo) : base(session, classInfo) { }

        Int16 _Mid = 0;

        [Persistent(nameof(Mid)), Key(false), DisplayName("ID"), VisibleInListView(false)]
        public Int16 Mid
        {
            get { return _Mid; }
            set
            {
                Int16 eskiMid = Mid;
                if (eskiMid == value)
                    return;
                _Mid = value;
                OnChanged(nameof(Mid), eskiMid, value);
            }
        }
    }
}
