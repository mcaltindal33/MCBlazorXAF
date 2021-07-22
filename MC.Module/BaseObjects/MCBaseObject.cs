using DevExpress.Data;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;

using System;
using System.ComponentModel;

namespace MC.Module.BaseObjects
{
    public enum OidInitializationMode { AfterConstruction, OnSaving }
    [NonPersistent, MemberDesignTimeVisibility(false)]
    public abstract class MCBaseObject : XPCustomObject
    {
        static MCBaseObject()
        {
            if (DevExpress.ExpressApp.FrameworkSettings.DefaultSettingsCompatibilityMode >= DevExpress.ExpressApp.FrameworkSettingsCompatibilityMode.v20_2)
            {
                OidInitializationMode = OidInitializationMode.AfterConstruction;
            }
        }
        protected MCBaseObject() : base() { }
        protected MCBaseObject(Session session) : base(session) { }
        protected MCBaseObject(Session session, XPClassInfo classInfo) : base(session, classInfo) { }

        public static bool IsXpoProfiling = false;
#if MediumTrust
		private Guid oid = Guid.Empty;
		[VisibleInListView(false), VisibleInDetailView(false), VisibleInLookupListView(false), Key(true), NonCloneable]
		public Guid Oid {
			get { return oid; }
			set { oid = value; }
		}
#else
        [Persistent("Mid"), Key(true), VisibleInListView(false), VisibleInDetailView(false), VisibleInLookupListView(false), MemberDesignTimeVisibility(false)]
        private Guid _Mid = Guid.Empty;
        [PersistentAlias(nameof(_Mid)), VisibleInListView(false), VisibleInDetailView(false), VisibleInLookupListView(false)]
        public Guid Mid
        {
            get { return _Mid; }
        }
#endif
        private bool isDefaultPropertyAttributeInit = false;
        private XPMemberInfo defaultPropertyMemberInfo;
        private static OidInitializationMode oidInitializationMode = OidInitializationMode.OnSaving;
        protected override void OnSaving()
        {
            base.OnSaving();
            if (!(Session is NestedUnitOfWork) && Session.IsNewObject(this))
            {
                if (_Mid.Equals(Guid.Empty))
                {
                    _Mid = XpoDefault.NewGuid();
                }
            }
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            if (oidInitializationMode == OidInitializationMode.AfterConstruction)
            {
                _Mid = XpoDefault.NewGuid();
            }
        }
        public override string ToString()
        {
            if (!IsXpoProfiling)
            {
                if (!isDefaultPropertyAttributeInit)
                {
                    string defaultPropertyName = string.Empty;
                    XafDefaultPropertyAttribute xafDefaultPropertyAttribute = XafTypesInfo.Instance.FindTypeInfo(GetType()).FindAttribute<XafDefaultPropertyAttribute>();
                    if (xafDefaultPropertyAttribute != null)
                    {
                        defaultPropertyName = xafDefaultPropertyAttribute.Name;
                    }
                    else
                    {
                        DefaultPropertyAttribute defaultPropertyAttribute = XafTypesInfo.Instance.FindTypeInfo(GetType()).FindAttribute<DefaultPropertyAttribute>();
                        if (defaultPropertyAttribute != null)
                        {
                            defaultPropertyName = defaultPropertyAttribute.Name;
                        }
                    }
                    if (!string.IsNullOrEmpty(defaultPropertyName))
                    {
                        defaultPropertyMemberInfo = ClassInfo.FindMember(defaultPropertyName);
                    }
                    isDefaultPropertyAttributeInit = true;
                }
                if (defaultPropertyMemberInfo != null)
                {
                    try
                    {
                        object obj = defaultPropertyMemberInfo.GetValue(this);
                        if (obj != null)
                        {
                            return obj.ToString();
                        }
                    }
                    catch
                    {
                    }
                }
            }
            return base.ToString();
        }
        public static OidInitializationMode OidInitializationMode
        {
            get { return oidInitializationMode; }
            set { oidInitializationMode = value; }
        }
    }
}
