
/*
    Copyright (C) 2020 Team Triple Double, Sabastian Peters
*/

using UnityEngine;
using UnityEditor;
using UnityEditor.Build.Reporting;

namespace Afloat.Util
{
    /*
        Class: DevelopmentBuilder
    */
    public class DevelopmentBuilder : Builder
    {
        
#region // ## PROTECTED METHODS ##   
        
        protected override BuildPlayerOptions GetConfig (BuildTarget target)
        {
            BuildPlayerOptions config = base.GetConfig(target);
            
            // adds flags
            config.options |= 
                BuildOptions.Development |
                BuildOptions.AllowDebugging | 
                BuildOptions.ConnectWithProfiler;
            
            // remove flags
            config.options &= ~(
                BuildOptions.StrictMode
            );

            return config;
        }
        
#endregion

    }
}