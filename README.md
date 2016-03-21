# extended-principals
This library provides access to extended (User) principals. The ones provided by System.DirectoryService.AccountManagement do not have enough properties.

# How to use this library
This library is really easy to use, even if you're not used to ``System.DirectoryServices.AccountManagement``.

## 1. Get a PrincipalContext
The first thing you need is get a PrincipalContext. You can do this in 2 different ways, choose the one you like.
```csharp
// using these
using Smartersoft.ExtendedPrincipals;
using System.DirectoryServices.AccountManagement;


// First, take the principal from the current user.
var context = UserPrincipal.Current.Context;

// Second, create a new principal (for the domain "Contoso")
// explore https://msdn.microsoft.com/en-us/library/system.directoryservices.accountmanagement.principalcontext.principalcontext.aspx for more Constructors.
var context = new PrincipalContext(ContextType.Domain, "Contoso");
```

Now that we have our PrincipalContext, you could do two things to use this class.
## 2a. FindBy...
We defined two methods to get an ExtendedUserPrincipal.
```csharp
using Smartersoft.ExtendedPrincipals;
using System.DirectoryServices.AccountManagement;

PrincipalContext context = null; // Choose your one way to get the PrincipalContext

// Find Extended user by Email
var extendedUser = ExtendedUserPrincipal.FindByEmail(context, "github@svrooij.nl");

// Find Extended user by identity value (DN,CN,UPN,...)
var extendedUser2 = ExtendedUserPrincipal.FindByIdentity(context, "myUPN");
```
## 2b. PrincipalSearcher
You can also use the Principal searcher to search through all users
```csharp

using Smartersoft.ExtendedPrincipals;
using System.DirectoryServices.AccountManagement;

PrincipalContext context = null; // Choose your one way to get the PrincipalContext

// Create a new ExtendedUserPrincipal, this is used as a filter
var searchUser = new ExtendedUserPrincipal(context);
searchUser.Company = "Cont*"; // support for wildcards!

// Create a principal search with this user.
PrincipalSearcher principalSearcher = new PrincipalSearcher(searchUser);

// Enumerate all results
foreach(ExtendedUserPrincipal user in principalSearcher.FindAll())
{
    // Do something with each user
    Console.WriteLine("{0} {1}", user.DisplayName, user.Company);
}
```
