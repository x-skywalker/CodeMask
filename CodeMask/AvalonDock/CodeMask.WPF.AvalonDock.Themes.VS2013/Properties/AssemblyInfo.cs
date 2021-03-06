﻿/************************************************************************

   AvalonDock







 

  

  **********************************************************************/

using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Markup;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.

[assembly: AssemblyTitle("Xceed Extended WPF Toolkit - AvalonDock VS2013 Theme")]
[assembly: AssemblyDescription("This assembly implements the VS2013 Theme for the AvalonDock layout system.")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("Xceed Extended WPF Toolkit - AvalonDock")]
[assembly: AssemblyCopyright("Copyright (C) Roman Novitskiy 2013-2014")]


// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.

[assembly: ComVisible(false)]
[assembly: CLSCompliant(true)]

//In order to begin building localizable applications, set 
//<UICulture>CultureYouAreCodingWith</UICulture> in your .csproj file
//inside a <PropertyGroup>.  For example, if you are using US english
//in your source files, set the <UICulture> to en-US.  Then uncomment
//the NeutralResourceLanguage attribute below.  Update the "en-US" in
//the line below to match the UICulture setting in the project file.

//[assembly: NeutralResourcesLanguage("en-US", UltimateResourceFallbackLocation.Satellite)]


[assembly: ThemeInfo(
    ResourceDictionaryLocation.None, //where theme specific resource dictionaries are located
    //(used if a resource is not found in the page, 
    // or application resource dictionaries)
    ResourceDictionaryLocation.SourceAssembly //where the generic resource dictionary is located
    //(used if a resource is not found in the page, 
    // app, or any theme specific resource dictionaries)
    )]
[assembly: XmlnsDefinition("https://github.com/x-skywalker/codemask", "CodeMask.WPF.AvalonDock.Themes")]

#pragma warning disable 1699

[assembly: AssemblyDelaySign(false)]
[assembly: AssemblyKeyFile(@"..\..\sn.snk")]
[assembly: AssemblyKeyName("")]
#pragma warning restore 1699