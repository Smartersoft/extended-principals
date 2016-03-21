using System;
using System.DirectoryServices.AccountManagement;

namespace Smartersoft.ExtendedPrincipals
{
    /// <summary>
    /// Encapsulates group accounts. Group accounts can be arbitrary collections of principal 
    /// objects or accounts created for administrative purposes.
    /// </summary>
    [DirectoryObjectClass("group")]
    [DirectoryRdnPrefix("CN")]
    public class ExtendedGroupPrincipal : GroupPrincipal
    {
        /// <summary>
        /// Initializes a new instance of the Smartersoft.ExtendedPrincipals.ExtendedGroupPrincipal
        ///     class by using the specified context.
        /// </summary>
        /// <param name="context">The System.DirectoryServices.AccountManagement.PrincipalContext that specifies
        /// the server or domain against which operations are performed.</param>
        public ExtendedGroupPrincipal(PrincipalContext context)
            : base(context)
        {

        }

        /// <summary>
        /// Returns an ExtendedGroupPrincipal object that matches the specified identity value.
        /// </summary>
        /// <param name="context">The System.DirectoryServices.AccountManagement.PrincipalContext that specifies the server or domain against which operations are performed.</param>
        /// <param name="identityValue"> The identity of the principal. This parameter can be any format that is contained in the System.DirectoryServices.AccountManagement.IdentityType enumeration.</param>
        /// <returns>A Smartersoft.ExtendedPrincipals.ExtendedGroupPrincipal object that matches the specified identity value, or null if no matches are found.</returns>
        public new static ExtendedGroupPrincipal FindByIdentity(PrincipalContext context, String identityValue)
        {
            return (ExtendedGroupPrincipal)FindByIdentityWithType(context, typeof(ExtendedGroupPrincipal), identityValue);
        }

        /// <summary>
        /// Creation date
        /// </summary>
        public DateTime Created
        {
            get { return (DateTime)ExtensionGet(Properties.Created)[0]; }
        }

        /// <summary>
        /// Last modified date
        /// </summary>
        public DateTime Changed
        {
            get
            {
                try
                {
                    return (DateTime)ExtensionGet(Properties.Changed)[0];
                }
                catch
                {
                    return Created;
                }
            }
        }
    }
}
