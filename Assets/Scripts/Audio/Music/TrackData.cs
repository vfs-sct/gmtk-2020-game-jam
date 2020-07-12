
/*
    Copyright (C) 2020 Team Triple Double, Sabastian Peters
*/

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using System.IO;
using System.Linq;
using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Interaction;

using GameSavvy.OpenUnityAttributes;
using Afloat.Util.Coroutines;
using System;

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
        [SerializeField] private string _midiFileName = "[Midi] - Track 1";



        // ## PROPERTIES ##

        public long SongTime => (long)Time.unscaledTime * 1000000;
        public string MidiFilePath => Path.Combine(
            Application.streamingAssetsPath,
            _midiFileName + ".mid"
        );

        
        // ## PRIVATE UTIL VARS ##

        CoroutineHandler _midiRoutine = null;
        CoroutineHandler _playRoutine = null;
        MetricTimeSpan[] _midiEventList = null;

#region // ## PUBLIC METHODS ##

        public void Play (MonoBehaviour target, AudioSource source, System.Action action)
        {
            _playRoutine = new CoroutineHandler(target);
            _midiRoutine = new CoroutineHandler(target);
            _playRoutine.Start(PlayRoutine(source, action));
        }

        public void Stop ()
        {
            _playRoutine.Stop();
            _midiRoutine.Stop();
        }
        
#endregion  
        
#region // ## PRIVATE METHODS ##   


        private IEnumerator PlayRoutine(AudioSource source, System.Action action)
        {
            // load clip
            source.clip = _loopClip;
            source.clip.LoadAudioData();
            source.loop = true;

            // load midi
            DetermineMidiEventList();
            
            yield return new WaitUntil(() => source.clip.loadState == AudioDataLoadState.Loaded);
            
            // play audio and midi events
            source.Play();
            _midiRoutine.Start(ActionOnMidi(action));

        }

        private IEnumerator ActionOnMidi (System.Action action)
        {
            long timeOfLastBeat = SongTime;
            long timeOfNextBeat = SongTime;

            int currentBeatIndex = 0;

            // keep on triggering action on beats until stopped
            while(true)
            {
                Debug.Log($"{SongTime} < {timeOfNextBeat}");
                // waits while we still have time to wait
                if(SongTime <= timeOfNextBeat)
                { 
                    continue;
                }

                // Debug.Log($"{currentBeatIndex} --> ({(currentBeatIndex + 1) % _midiEventList.Length}) [{_midiEventList.Length}]");

                // updates time target
                timeOfLastBeat = timeOfNextBeat;
                timeOfNextBeat = timeOfLastBeat + _midiEventList[currentBeatIndex].TotalMicroseconds;
                currentBeatIndex = (currentBeatIndex + 1) % _midiEventList.Length; /// keeps cycling through midi file

                // does action
                action();
                yield return null;
            }
        }



        private void DetermineMidiEventList ()
        {
            MidiFile file = MidiFile.Read(MidiFilePath);
            TempoMap tempoMap = file.GetTempoMap();

            Debug.Log($"{tempoMap.Tempo}");

            _midiEventList = file.GetTimedEvents()
                .Select(e => e.TimeAs<MetricTimeSpan>(tempoMap))
                .ToArray();
        }
        
#endregion

    }
}