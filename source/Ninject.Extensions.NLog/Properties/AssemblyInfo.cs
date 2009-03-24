#region Using Directives

using System.Reflection;
using System.Runtime.InteropServices;
using System.Security;

#endregion

[assembly : AssemblyTitle( "Ninject NLog Integration Library" )]
[assembly : Guid( "92c399f0-0b4e-11dd-bd0b-0800200c9a66" )]

#if !NO_PARTIAL_TRUST

[assembly : AllowPartiallyTrustedCallers]
#endif