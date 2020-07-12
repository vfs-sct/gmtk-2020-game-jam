
/*
    Copyright (C) 2020 Team Triple Double, Sabastian Peters
*/

using System.Collections;
using Afloat.Events;
using Afloat.Util.Coroutines;
using GameSavvy.OpenUnityAttributes;
using UnityEngine;

namespace Afloat
{
    /*
        Class: MusicController
    */
    public class MusicController : MonoBehaviour
    {

        public static MusicController _instance = null;
        public static int _lastTrackIndex = 0;
        
        // ## UNITY EDITOR ##

        [Header("References")]
        [SerializeField] private TrackData[] _trackList = null;

        [Header("Lines")]
        [SerializeField] private AudioSource _line1 = null;
        [SerializeField] private AudioSource _line2 = null;
        [SerializeField] private AudioSource _transitionLine = null;

        [Header("Song Transition")]
        [SerializeField] private AudioClip _trackStart = null;
        [SerializeField] private AudioClip _trackStop = null;

        [Header("On Beat")]
        [SerializeField] private AudioClip _actionClip = null;
        [SerializeField] private GameEvent _shootEvent = null;
        
        
        // ## PROPERTIES  ##

        private AudioSource FreeLine
        {
            get
            {
                if(_lastLine == _line1) return _lastLine = _line2;
                if(_lastLine == _line2) return _lastLine = _line1;
                
                return _lastLine = _line1; /// when null
            }
        }
        
        
        // ## PUBLIC VARS ##
        
        
        // ## PROTECTED VARS ##
        
        
        // ## PRIVATE UTIL VARS ##
        
        private TrackData _currentTrack = null;
        private AudioSource _lastLine = null;
        private CoroutineHandler _playRoutine = null;
        
        
              
#region // ## MONOBEHAVIOUR METHODS ##
                
        void Start ()
        {
            _instance = this;
            _playRoutine = new CoroutineHandler(this);

            PlayTrack(_trackList[_lastTrackIndex]);
            _lastTrackIndex = (_lastTrackIndex + 1) % _trackList.Length;
        }
        
#endregion      

#region // ## PUBLIC METHODS ##

        public void PlayTrack (TrackData track)
        {
            _playRoutine.Start(PlayRoutine(track));
        }
        
        public void Stop ()
        {
            _playRoutine.Start(StopRoutine());
        }

        public static void GlobalStop()
        {
            _instance.Stop();
        }

#endregion       

#region // ## <SOME INTERFACE> METHODS ##   
                
        
        
#endregion
        
#region // ## PROTECTED METHODS ##   
        
        
        
#endregion
        
#region // ## PRIVATE METHODS ##   

        private IEnumerator PlayRoutine (TrackData track)
        {
            yield return StopRoutine(); /// stops last track

            // plays and waits for transition clip
            _transitionLine.clip = _trackStart;
            _transitionLine.Play();
            yield return new WaitForSeconds(_trackStart.length);

            // plays new track
            _currentTrack = track;
            _currentTrack.Play(this, FreeLine, OnBeat);
        }

        private IEnumerator StopRoutine ()
        {
            if(_currentTrack != null)
            {
                // stops current track if exists
                _currentTrack.Stop();
                _currentTrack = null;

                // plays and waits for transition clip
                _transitionLine.clip = _trackStop;
                _transitionLine.Play();
                yield return new WaitForSeconds(_trackStop.length);
            }
        }
        
        private void OnBeat ()
        {
            if(Time.timeScale < 0.5f) return;

            if(_actionClip != null) AudioSource.PlayClipAtPoint(_actionClip, Camera.main.transform.position);
            _shootEvent.Raise();
        }
        
#endregion

    }
}