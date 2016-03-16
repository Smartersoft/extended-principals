using System;
using System.DirectoryServices.AccountManagement;

namespace Smartersoft.ExtendedPrincipals
{
    /// <summary>
    /// Encapsulates principals that are user accounts and extends these with extra properties.
    /// </summary>
    [DirectoryObjectClass("user")]
    [DirectoryRdnPrefix("CN")]
    public class ExtendedUserPrincipal : UserPrincipal
    {
        /// <summary>
        /// Initializes a new instance of the Smartersoft.ExtendedPrincipals.ExtendedUserPrincipal
        /// class by using the specified context.
        /// </summary>
        /// <param name="context">The System.DirectoryServices.AccountManagement.PrincipalContext that specifies the server or domain against which operations are performed.</param>
        public ExtendedUserPrincipal(PrincipalContext context) : base(context)
        {
            
        }

        /// <summary>
        /// Initializes a new instance of the System.DirectoryServices.AccountManagement.UserPrincipal
        /// class by using the specified context, SAM account name, password, and enabled value.
        /// </summary>
        /// <param name="context">The System.DirectoryServices.AccountManagement.PrincipalContext that specifies the server or domain against which operations are performed.</param>
        /// <param name="samAccountName">The SAM account name for this user principal.</param>
        /// <param name="password">The password for this account.</param>
        /// <param name="enabled">A Boolean value that specifies whether the account is enabled.</param>
        public ExtendedUserPrincipal(PrincipalContext context, string samAccountName, string password, bool enabled)
            : base(context, samAccountName, password, enabled)
        {

        }

        #region FindBy.... methods
        /// <summary>
        /// Returns an ExtendedUserPrincipal object that matches the specified identity value.
        /// </summary>
        /// <param name="context">The System.DirectoryServices.AccountManagement.PrincipalContext that specifies the server or domain against which operations are performed.</param>
        /// <param name="identityValue"> The identity of the principal. This parameter can be any format that is contained in the System.DirectoryServices.AccountManagement.IdentityType enumeration.</param>
        /// <returns>A Smartersoft.ExtendedPrincipals.ExtendedUserPrincipal object that matches the specified identity value, or null if no matches are found.</returns>
        public new static ExtendedUserPrincipal FindByIdentity(PrincipalContext context, String identityValue)
        {
            return (ExtendedUserPrincipal)FindByIdentityWithType(context, typeof(ExtendedUserPrincipal), identityValue);
        }

        /// <summary>
        /// Returns an ExtendedUserPrincipal object that matches the specified emailaddress.
        /// </summary>
        /// <param name="context">The System.DirectoryServices.AccountManagement.PrincipalContext that specifies the server or domain against which operations are performed.</param>
        /// <param name="emailaddress">The emailaddres of the user.</param>
        /// <returns>A Smartersoft.ExtendedPrincipals.ExtendedUserPrincipal object that matches the specified identity value, or null if no matches are found.</returns>
        public static ExtendedUserPrincipal FindByEmail(PrincipalContext context, string emailaddress)
        {
            var p = new ExtendedUserPrincipal(context);
            p.EmailAddress = emailaddress;
            var searcher = new PrincipalSearcher(p);
            var result = searcher.FindOne();
            if (result == null)
                return null;
            return result as ExtendedUserPrincipal;
        }

        #endregion

        #region Extra properties
        /// <summary>
        /// DateTime of the last change
        /// </summary>
        public DateTime Changed
        {
            get
            {
                try
                {
                    return DateTime.Parse(GetStringForAttribute(Properties.Changed));
                } catch
                {
                    return Created;
                }
            }
        }

        /// <summary>
        /// Company of the user
        /// </summary>
        [DirectoryProperty(Properties.Company)]
        public string Company
        {
            get { return GetStringForAttribute(Properties.Company); }
            set { SetAttributeWithString(Properties.Company, value); }
        }
        
        /// <summary>
        /// Creation time
        /// </summary>
        public DateTime Created
        {
            get { return DateTime.Parse(GetStringForAttribute(Properties.Created)); }
        }

        /// <summary>
        /// Department of the user.
        /// </summary>
        [DirectoryProperty(Properties.Department)]
        public string Department
        {
            get { return GetStringForAttribute(Properties.Department); }
            set { SetAttributeWithString(Properties.Department, value); }
        }

        /// <summary>
        /// HomePhone of the user.
        /// </summary>
        [DirectoryProperty(Properties.HomePhone)]
        public string HomePhone
        {
            get { return GetStringForAttribute(Properties.HomePhone); }
            set { SetAttributeWithString(Properties.HomePhone, value); }
        }

        /// <summary>
        /// Initials of the user.
        /// </summary>
        [DirectoryProperty(Properties.Initials)]
        public string Initials
        {
            get { return GetStringForAttribute(Properties.Initials); }
            set { SetAttributeWithString(Properties.Initials, value); }
        }

        /// <summary>
        /// Manager of the user, (as DN remember that when setting this value)
        /// </summary>
        [DirectoryProperty(Properties.Manager)]
        public string ManagerDN
        {
            get { return GetStringForAttribute(Properties.Manager); }
            set { SetAttributeWithString(Properties.Manager, value); }
        }

        /// <summary>
        /// Get the manager of the user.
        /// </summary>
        /// <returns>A Smartersoft.ExtendedPrincipals.ExtendedUserPrincipal object that matches the specified Manager DN, or null if no manager has been set.</returns>
        public ExtendedUserPrincipal GetManager()
        {
            var manager = ManagerDN;
            if (string.IsNullOrEmpty(manager))
                return null;
            return ExtendedUserPrincipal.FindByIdentity(this.Context, manager);
        }

        /// <summary>
        /// Mobile number of the user.
        /// </summary>
        [DirectoryProperty(Properties.Mobile)]
        public string Mobile
        {
            get { return GetStringForAttribute(Properties.Mobile); }
            set { SetAttributeWithString(Properties.Mobile, value); }
        }

        /// <summary>
        /// Office of the user.
        /// </summary>
        [DirectoryProperty(Properties.Office)]
        public string Office
        {
            get { return GetStringForAttribute(Properties.Office); }
            set { SetAttributeWithString(Properties.Office, value); }
        }

        /// <summary>
        /// Personal title of the user.
        /// </summary>
        [DirectoryProperty(Properties.PersonalTitle)]
        public string PersonalTitle
        {
            get { return GetStringForAttribute(Properties.PersonalTitle); }
            set { SetAttributeWithString(Properties.PersonalTitle, value); }
        }

        /// <summary>
        /// Profile path of the user.
        /// </summary>
        [DirectoryProperty(Properties.ProfilePath)]
        public string ProfilePath
        {
            get { return GetStringForAttribute(Properties.ProfilePath); }
            set { SetAttributeWithString(Properties.ProfilePath, value); }
        }

        /// <summary>
        /// Proxy addresses of user.
        /// </summary>
        [DirectoryProperty(Properties.ProxyAddresses)]
        public string[] ProxyAddresses
        {
            get { return GetArrayForAttribute(Properties.ProxyAddresses); }
            set { SetAttribute(Properties.ProxyAddresses, value); }
        }

        /// <summary>
        /// State of user.
        /// </summary>
        [DirectoryProperty(Properties.State)]
        public string State
        {
            get { return GetStringForAttribute(Properties.State); }
            set { SetAttributeWithString(Properties.State, value); }
        }

        /// <summary>
        /// Phone number of user.
        /// </summary>
        [DirectoryProperty(Properties.TelephoneNumber)]
        public string TelephoneNumber
        {
            get { return GetStringForAttribute(Properties.TelephoneNumber); }
            set { SetAttributeWithString(Properties.TelephoneNumber, value); }
        }

        /// <summary>
        /// Title of user.
        /// </summary>
        [DirectoryProperty(Properties.Title)]
        public string Title
        {
            get { return GetStringForAttribute(Properties.Title); }
            set { SetAttributeWithString(Properties.Title, value); }
        }

        #endregion

        #region Extra filters
        private MemberOfFilter _memberOfFilter;

        /// <summary>
        /// You could use this filter to create a PrincipalSearcher based on groupname.
        /// </summary>
        public MemberOfFilter MemberOfFilter
        {
            get
            {
                if (_memberOfFilter == null)
                    _memberOfFilter = new MemberOfFilter(this);

                return _memberOfFilter;
            }
        }
        #endregion

        #region Calling backing object
        /// <summary>
        /// Get a string array value for an attribute.
        /// </summary>
        /// <param name="attribute">The name of the property in the backing object</param>
        public string[] GetArrayForAttribute(string attribute)
        {
            try
            {
                object[] attributeRaw = ExtensionGet(attribute);
                if (attributeRaw.Length <= 0)
                {
                    var leeg = new String[1];
                    leeg[0] = String.Empty;
                    return leeg;
                }
                var values = new String[attributeRaw.Length];
                for (Int32 i = 0; i < attributeRaw.Length; i++)
                {
                    values[i] = attributeRaw[i].ToString().Trim();
                }

                return values;
            }
            catch //(Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Get the string value for an attribute
        /// </summary>
        /// <param name="attribute">The name of the property in the backing object</param>
        public string GetStringForAttribute(string attribute)
        {
            return GetArrayForAttribute(attribute)[0];
        }

        /// <summary>
        /// Set an attribute of the backing object
        /// </summary>
        /// <param name="attribute">The name of the property in the backing object</param>
        /// <param name="value">New value of the property</param>
        /// <remarks>This is UNCHECKED so just with caution!</remarks>
        public void SetAttribute(string attribute,object value)
        {
            this.ExtensionSet(attribute, value);
        }

        /// <summary>
        /// Set an attribute with a string value
        /// </summary>
        /// <param name="attribute">The name of the property in the backing object</param>
        /// <param name="value">New value of the property</param>
        public void SetAttributeWithString(string attribute,string value)
        {
            if (string.IsNullOrEmpty(value))
                this.ExtensionSet(attribute, null);
            else
                this.ExtensionSet(attribute, value);
        }
        #endregion
    }
}