﻿
/*
    Copyright (C) 2020 Team Triple Double, Sabastian Peters
*/

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using GameSavvy.OpenUnityAttributes;



namespace Afloat
{
    /*
        Class: TrackData
    */
    [CreateAssetMenu(menuName="Custom/Audio/Music Track")] 
    public class TrackData : ScriptableObject
    {



        // ## UNITY EDITOR ##
        
        [SerializeField] private AudioClip _loopClip = null;
        [SerializeField] private int _bpm = 120;
        [SerializeField] private int _beatCountInBar = 4;
        
        [ReorderableList]
        [SerializeField] private List<float> _beatList;


        
        // ## PRIVATE UTIL VARS ##

        float _beatLength = -1; /// length of a beat in seconds
        
        
        
              
#region // ## SCRIPTABLE OBJECT METHODS ##
                
        private void OnEnable()
        {
            _beatLength = 60 / _bpm; /// reciprocal to get minutes of beat, 60 to get seconds
            _beatList.Sort();
        }
        
#endregion      

#region // ## PUBLIC METHODS ##
                
        public IEnumerator CallOnBeat(System.Action action)
        {
            float lastBeatValue = 0;
            foreach (var beat in _beatList)
            {
                yield return WaitBetweenBeats(beat, lastBeatValue);
                action();
            }

            // wait till end of bar
            yield return WaitBetweenBeats(_beatCountInBar, lastBeatValue);
        }
        
#endregion  
        
#region // ## PRIVATE METHODS ##   

        private CustomYieldInstruction WaitBetweenBeats (float a, float b)
        {
            Debug.Log($"{_beatLength} * {a} - {b} ({Mathf.Clamp01(a - b)})");
            return new WaitForSecondsRealtime(
                _beatLength * Mathf.Clamp01(a - b)
            );
        }
        
#endregion

#if UNITY_EDITOR

        private void OnValidate()
        {
            foreach (var beat in _beatList)
            {
                if(_beatCountInBar < beat)
                {
                    Debug.LogError($"Music Track {name} has beats outside of the total bar length", this);
                    break;
                }
            }
        }

#endif

    }
}