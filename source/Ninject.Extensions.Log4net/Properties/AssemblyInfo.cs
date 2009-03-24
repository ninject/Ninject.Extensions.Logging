#region Using Directives

using System.Reflection;
using System.Runtime.InteropServices;
using System.Security;

#endregion

[assembly : AssemblyTitle( "Ninject log4net Integration Library" )]
[assembly : Guid( "5ca064a2-2465-4381-8fdf-dc4059997360" )]

#if !NO_PARTIAL_TRUST

[assembly : AllowPartiallyTrustedCallers]
#endif