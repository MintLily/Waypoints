using System;
using System.Resources;
using System.Reflection;
using System.Runtime.InteropServices;
using MelonLoader;

[assembly: AssemblyTitle(Waypoints.BuildInfo.Name)]
[assembly: AssemblyDescription(Waypoints.BuildInfo.Description)]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany(Waypoints.BuildInfo.Company)]
[assembly: AssemblyProduct(Waypoints.BuildInfo.Name)]
[assembly: AssemblyCopyright("Created by " + Waypoints.BuildInfo.Author)]
[assembly: AssemblyTrademark(Waypoints.BuildInfo.Company)]
[assembly: AssemblyCulture("")]
[assembly: ComVisible(false)]
//[assembly: Guid("")]
[assembly: AssemblyVersion(Waypoints.BuildInfo.Version)]
[assembly: AssemblyFileVersion(Waypoints.BuildInfo.Version)]
[assembly: NeutralResourcesLanguage("en")]
[assembly: MelonInfo(typeof(Waypoints.Main),
    Waypoints.BuildInfo.Name,
    Waypoints.BuildInfo.Version,
    Waypoints.BuildInfo.Author,
    Waypoints.BuildInfo.DownloadLink)]
[assembly: MelonColor(ConsoleColor.Yellow)]

//[assembly: MelonOptionalDependencies("", "", "", "")]
// Create and Setup a MelonModGame to mark a Mod as Universal or Compatible with specific Games.
// If no MelonModGameAttribute is found or any of the Values for any MelonModGame on the Mod is null or empty it will be assumed the Mod is Universal.
// Values for MelonModGame can be found in the Game's app.info file or printed at the top of every log directly beneath the Unity version.
[assembly: MelonGame("VRChat", "VRChat")]