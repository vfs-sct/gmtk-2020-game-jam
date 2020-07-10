
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

        [System.Serializable]
        public class Beat 
        {
            [ReorderableList]
            public List<float> NoteList;
        }



        // ## UNITY EDITOR ##
        
        [SerializeField] private AudioClip _loop = null;
        [SerializeField] private int _bpm = 120;
        
        [ReorderableList]
        [SerializeField] private List<Beat> _beatList;


        
        // ## PRIVATE UTIL VARS ##

        float _beatLength = -1; /// length of a beat in seconds
        
        
        
              
#region // ## MONOBEHAVIOUR METHODS ##
                
        private void Awake()
        {
            _beatLength = 60 / _bpm; /// reciprocal to get minutes of beat, 60 to get seconds
            OrderLists();
        }
        
#endregion      

#region // ## PUBLIC METHODS ##
                
        public IEnumerator WaitForBeat(System.Action action)
        {
            foreach (var beat in _beatList)
            {
                float lastNoteValue = 0;
                foreach (var note in beat.NoteList)
                {
                    yield return new WaitForSecondsRealtime(
                        _beatLength * Mathf.Clamp01(note - lastNoteValue)
                    );
                    
                    action();
                }
            }
        }
        
#endregion       

#region // ## <SOME INTERFACE> METHODS ##   
                
        
        
#endregion
        
#region // ## PROTECTED METHODS ##   
        
        
        
#endregion
        
#region // ## PRIVATE METHODS ##   
        
        private void OrderLists ()
        {
            foreach (var beat in _beatList)
            {
                beat.NoteList.Sort();
            }
        }
        
#endregion

    }
}