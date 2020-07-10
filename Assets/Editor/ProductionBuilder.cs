
/*
    Copyright (C) 2020 Team Triple Double, Sabastian Peters
*/

using UnityEngine;
using UnityEditor;

namespace Afloat.Util
{
    /*
        Class: ProductionBuilder
    */
    public class ProductionBuilder : Builder
    {

#region // ## PROTECTED METHODS ##   
        
        
        protected override BuildPlayerOptions GetConfig (BuildTarget target)
        {
            BuildPlayerOptions config = base.GetConfig(target);
            
            // adds flags
            config.options |= BuildOptions.StrictMode;

            return config;
        }
        
#endregion

    }
}