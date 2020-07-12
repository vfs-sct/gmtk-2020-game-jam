
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
        [SerializeField] private int _bpm = 120;



        // ## PROPERTIES ##

        public MetricTimeSpan ClipLength => MetricTimeSpanFromSeconds(_loopClip.length);
        public MetricTimeSpan TargetTime => MetricTimeSpanFromSeconds(Time.realtimeSinceStartup);
        public string MidiFilePath => Path.Combine(
            Application.streamingAssetsPath,
            _midiFileName + ".mid"
        );

        
        // ## PRIVATE UTIL VARS ##

        CoroutineHandler _midiRoutine = null;
        CoroutineHandler _playRoutine = null;
        MetricTimeSpan[] _midiEventList = null;
        MetricTimeSpan[] _trackLength = null;

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
            MetricTimeSpan startTime = TargetTime;
            MetricTimeSpan timeOfNextBeat = TargetTime;

            int currentBeatIndex = 0;

            // keep on triggering action on beats until stopped
            while(true)
            {

                // waits while we still have time to wait
                if(TargetTime <= timeOfNextBeat)
                { 
                    yield return null;
                    continue;
                }

                Debug.Log($"[] {currentBeatIndex} --> ({(currentBeatIndex + 1) % _midiEventList.Length}) [{_midiEventList.Length}]");

                // updates time target

                /// on loop end
                currentBeatIndex++;
                if(_midiEventList.Length <= currentBeatIndex)
                {
                    currentBeatIndex = 0;
                    startTime += ClipLength; /// resets time
                }

                timeOfNextBeat = startTime + _midiEventList[currentBeatIndex]; /// sets next target time

                // does action
                action();
            }
        }


        
        private MetricTimeSpan MetricTimeSpanFromSeconds (float seconds)
        {
            return new MetricTimeSpan((long)(seconds * 10000) * 100); /// 5 digits precision (10000), rest of 0s are for microseconds
        }


        private void DetermineMidiEventList ()
        {
            MidiFile file = MidiFile.Read(MidiFilePath);
            TempoMap tempoMap = TempoMap.Create(Tempo.FromBeatsPerMinute(_bpm));

            _midiEventList = file.GetTimedEvents()
                .Where(e => e.Event is NoteOnEvent)
                .Select(e => e.TimeAs<MetricTimeSpan>(tempoMap))
                .ToArray();
        }
        
#endregion

    }
}