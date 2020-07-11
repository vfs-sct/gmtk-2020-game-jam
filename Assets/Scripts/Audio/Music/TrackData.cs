
/*
    Copyright (C) 2020 Team Triple Double, Sabastian Peters
*/

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using GameSavvy.OpenUnityAttributes;
using Afloat.Util.Coroutines;

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

        CoroutineHandler _playRoutine = null;
        float _beatLength = -1; /// length of a beat in seconds
        
        
        
              
#region // ## SCRIPTABLE OBJECT METHODS ##
                
        private void OnEnable()
        {
            _beatLength = 60f / _bpm; /// reciprocal to get minutes of beat, 60 to get seconds
            _beatList.Sort();
        }
        
#endregion      

#region // ## PUBLIC METHODS ##

        public void Play (MonoBehaviour target, AudioSource source, System.Action action)
        {
            _playRoutine = new CoroutineHandler(target);
            _playRoutine.Start(PlayRoutine(source, action));
        }

        public void Stop ()
        {
            _playRoutine.Stop();
        }
        
#endregion  
        
#region // ## PRIVATE METHODS ##   


        private IEnumerator PlayRoutine(AudioSource source, System.Action action)
        {
            // play clip
            source.clip = _loopClip;
            source.clip.LoadAudioData();
            source.loop = true;
            
            yield return new WaitUntil(() => source.clip.loadState == AudioDataLoadState.Loaded);
            
            source.Play();

            // keep on triggering action on beats until stopped
            while(true)
            {
                float lastBeatValue = 0;
                foreach (var beat in _beatList)
                {
                    yield return WaitBetweenBeats(beat, lastBeatValue);
                    action();

                    lastBeatValue = beat;
                }

                // wait till end of bar
                yield return WaitBetweenBeats(_beatCountInBar, lastBeatValue);
            }
        }

        private CustomYieldInstruction WaitBetweenBeats (float a, float b)
        {
            return new WaitForSecondsRealtime(
                _beatLength * (a - b)
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