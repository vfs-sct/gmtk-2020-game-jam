﻿
/*
    Copyright (C) 2020 Team Triple Double, Sabastian Peters
*/

using System.Collections;
using System.IO;
using System.Linq;
using Afloat.Events;
using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Interaction;
using UnityEngine;

namespace Afloat
{
    /*
        Class: MusicController
    */
    public class MusicController : MonoBehaviour
    {
        
        // ## UNITY EDITOR ##

        [Header("References")]
        [SerializeField] private AudioSource _target;
        [SerializeField] private TrackData _track;

        [Header("On Beat")]
        [SerializeField] private AudioClip _actionClip;
        [SerializeField] private GameEvent _shootEvent;
        
        
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
            AudioSource.PlayClipAtPoint(_actionClip, Camera.main.transform.position);
            _shootEvent.Raise();
        }
        
#endregion

    }
}