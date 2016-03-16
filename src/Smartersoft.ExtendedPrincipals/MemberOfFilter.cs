using System.DirectoryServices.AccountManagement;

namespace Smartersoft.ExtendedPrincipals
{
    /// <summary>
    /// Member Of Filter used in ExtendedUserPrincipal
    /// </summary>
    public class MemberOfFilter : AdvancedFilters
    {
        /// <summary>
        /// Create a new memberof filter.
        /// </summary>
        /// <param name="principal">The principal the filter is used for.</param>
        public MemberOfFilter(Principal principal) : base(principal) { }

        /// <summary>
        /// Set the filter based on groupPrincipal.
        /// </summary>
        /// <param name="groupPrincipal">The Group Principal used for the filter.</param>
        public void MemberOf(GroupPrincipal groupPrincipal)
        {
            AdvancedFilterSet(Properties.MemberOf, groupPrincipal.DistinguishedName, typeof(string), MatchType.Equals);
        }
    }
}