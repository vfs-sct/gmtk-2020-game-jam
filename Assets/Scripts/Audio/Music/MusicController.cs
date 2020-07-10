
/*
    Copyright (C) 2020 Team Triple Double, Sabastian Peters
*/

using System.Collections;
using UnityEngine;

namespace Afloat
{
    /*
        Class: MusicController
    */
    public class MusicController : MonoBehaviour
    {
        
        // ## UNITY EDITOR ##

        [SerializeField] private TrackData _track;
        
        
        // ## PROPERTIES  ##
        
        
        // ## PUBLIC VARS ##
        
        
        // ## PROTECTED VARS ##
        
        
        // ## PRIVATE UTIL VARS ##
        
        
        
              
#region // ## MONOBEHAVIOUR METHODS ##
                
        IEnumerator Start ()
        {
            yield return _track.CallOnBeat(OnBeat);
        }
        
#endregion      

#region // ## PUBLIC METHODS ##
                
        
        
#endregion       

#region // ## <SOME INTERFACE> METHODS ##   
                
        
        
#endregion
        
#region // ## PROTECTED METHODS ##   
        
        
        
#endregion
        
#region // ## PRIVATE METHODS ##   
        
        private void OnBeat ()
        {
            UnityEditor.EditorApplication.Beep();
        }
        
#endregion

    }
}