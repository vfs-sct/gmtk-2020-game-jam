
/*
    Copyright (C) 2020 Team Triple Double, Sabastian Peters
*/

using UnityEditor;

namespace Afloat.Util.BuildCLI
{
    /*
        Class: Development

        A colection of static methods to build the game from the CLI.
        Also used to create MenuItems so it can be build from in-editor.
        Please note that while everthing in the class is static, the class itself must not be static.
        Unity's CLI can only access non-static classes it appears.
        ([source](https://forum.unity.com/threads/executemethod-class-performbuild-could-not-be-found.222644/))
    */

#region // ## DEVELOPMENT METHODS ##
        
    public class Development
    {
        // Function: Windows
        // Does a standard build of Windows.
        // Access from CLI using `-executeMethod Afloat.Util.BuildCLI.Development.Windows "C:/Path/To/Your/Exe/Destination/Folder"`.
        [MenuItem("Build/Development/Windows")]
        public static void Windows ()
        {
            new DevelopmentBuilder().Build(BuildTarget.StandaloneWindows64);
        }   

        // Function: WindowsScripts
        // Rebuilds all scripts for Windows.
        // Access from CLI using `-executeMethod Afloat.Util.BuildCLI.Development.WindowsScripts "C:/Path/To/Your/Exe/Destination/Folder"`.
        [MenuItem("Build/Development/Windows Scripts Rebuild", false, 100)]
        public static void WindowsScripts ()
        {
            new DevelopmentBuilder().RebuildScripts(BuildTarget.StandaloneWindows64);
        }




        // Function: OSX
        // Does a standard build of MacOSX.
        // Access from CLI using `-executeMethod Afloat.Util.BuildCLI.Development.OSX "C:/Path/To/Your/Exe/Destination/Folder"`.
        [MenuItem("Build/Development/MacOSX")]
        public static void OSX ()
        {
            new DevelopmentBuilder().Build(BuildTarget.StandaloneOSX);
        }   

        // Function: OSXScripts
        // Rebuilds all scripts for Windows.
        // Access from CLI using `-executeMethod Afloat.Util.BuildCLI.Development.OSXScripts "C:/Path/To/Your/Exe/Destination/Folder"`.
        [MenuItem("Build/Development/MacOSX Scripts Rebuild", false, 100)]
        public static void OSXScripts ()
        {
            new DevelopmentBuilder().RebuildScripts(BuildTarget.StandaloneOSX);
        }




        // Function: Linux
        // Does a standard build of Linux.
        // Access from CLI using `-executeMethod Afloat.Util.BuildCLI.Development.Linux "C:/Path/To/Your/Exe/Destination/Folder"`.
        [MenuItem("Build/Development/Linux")]
        public static void Linux ()
        {
            // TODO: validate this once we fix Wwise integration
            new DevelopmentBuilder().Build(BuildTarget.StandaloneLinux64);
        }

        // Function: LinuxScripts
        // Rebuilds all scripts for Linux.
        // Access from CLI using `-executeMethod Afloat.Util.BuildCLI.Development.LinuxScripts "C:/Path/To/Your/Exe/Destination/Folder"`.
        [MenuItem("Build/Development/Linux Scripts Rebuild", false, 100)]
        public static void LinuxScripts ()
        {
            new DevelopmentBuilder().RebuildScripts(BuildTarget.StandaloneLinux64);
        }

    }
        
#endregion       

#region // ## PRODUCTION METHODS ##   
                
    public class Production
    {
        // Function: Windows
        // Does a standard build of Windows.
        // Access from CLI using `-executeMethod Afloat.Util.BuildCLI.Production.Windows "C:/Path/To/Your/Exe/Destination/Folder"`.
        [MenuItem("Build/Production/Windows")]
        public static void Windows ()
        {
            new DevelopmentBuilder().Build(BuildTarget.StandaloneWindows64);
        }   

        // Function: WindowsScripts
        // Rebuilds all scripts for Windows.
        // Access from CLI using `-executeMethod Afloat.Util.BuildCLI.Production.WindowsScripts "C:/Path/To/Your/Exe/Destination/Folder"`.
        [MenuItem("Build/Production/Windows Scripts Rebuild", false, 100)]
        public static void WindowsScripts ()
        {
            new DevelopmentBuilder().RebuildScripts(BuildTarget.StandaloneWindows64);
        }




        // Function: OSX
        // Does a standard build of MacOSX.
        // Access from CLI using `-executeMethod Afloat.Util.BuildCLI.Production.OSX "C:/Path/To/Your/Exe/Destination/Folder"`.
        [MenuItem("Build/Production/MacOSX")]
        public static void OSX ()
        {
            new DevelopmentBuilder().Build(BuildTarget.StandaloneOSX);
        }   

        // Function: OSXScripts
        // Rebuilds all scripts for Windows.
        // Access from CLI using `-executeMethod Afloat.Util.BuildCLI.Production.OSXScripts "C:/Path/To/Your/Exe/Destination/Folder"`.
        [MenuItem("Build/Production/MacOSX Scripts Rebuild", false, 100)]
        public static void OSXScripts ()
        {
            new ProductionBuilder().RebuildScripts(BuildTarget.StandaloneOSX);
        }




        // Function: Linux
        // Does a standard build of Linux.
        // Access from CLI using `-executeMethod Afloat.Util.BuildCLI.Production.Linux "C:/Path/To/Your/Exe/Destination/Folder"`.
        [MenuItem("Build/Production/Linux")]
        public static void Linux ()
        {
            // TODO: validate this once we fix Wwise integration
            new ProductionBuilder().Build(BuildTarget.StandaloneLinux64);
        }

        // Function: LinuxScripts
        // Rebuilds all scripts for Linux.
        // Access from CLI using `-executeMethod Afloat.Util.BuildCLI.Production.LinuxScripts "C:/Path/To/Your/Exe/Destination/Folder"`.
        [MenuItem("Build/Production/Linux Scripts Rebuild", false, 100)]
        public static void LinuxScripts ()
        {
            new ProductionBuilder().RebuildScripts(BuildTarget.StandaloneLinux64);
        }

    }
        
#endregion

}