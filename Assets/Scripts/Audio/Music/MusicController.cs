
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

        [SerializeField] private AudioClip _actionClip;
        [SerializeField] private AudioSource _target;
        [SerializeField] private TrackData _track;
        
        
        // ## PROPERTIES  ##
        
        
        // ## PUBLIC VARS ##
        
        
        // ## PROTECTED VARS ##
        
        
        // ## PRIVATE UTIL VARS ##
        
        
        
              
#region // ## MONOBEHAVIOUR METHODS ##
                
        void Start ()
        {
            _track.Play(this, _target, OnBeat);
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
            _target.PlayOneShot(_actionClip);
            Debug.Log($"A");
        }
        
#endregion

    }
}