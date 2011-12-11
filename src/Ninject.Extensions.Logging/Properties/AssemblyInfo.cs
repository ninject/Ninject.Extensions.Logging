#region Using Directives

using System.Reflection;
using System.Runtime.InteropServices;
using System.Security;

#endregion

[assembly: AssemblyTitle("Ninject Logging Integration Library")]
[assembly: Guid("a95066ef-205e-4eca-b164-76725248bd0d")]

#if !NO_PARTIAL_TRUST
[assembly: AllowPartiallyTrustedCallers]
#endif