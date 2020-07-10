/*
    Copyright (C) 2020 Team Triple Double, Sabastian Peters, Diego Castagne
*/
using UnityEngine;
using System.Collections.Generic;

namespace Afloat.Util.SceneManagement
{
    public class PlayerInitializer : MonoBehaviour
    {
        // ## UNITY EDITOR ##
        [SerializeField] Transform[] _spawnPoints = null;
        [SerializeField] bool _loadAudio = false;
        [SerializeField] bool _loadUI = false;
        [SerializeField] bool _loadMain = false;
        [SerializeField] bool _loadDebugUI = false;

        // ## PUBLIC VARS ##
        public static Transform[] SpawnPoints;

#region // ## MONOBEHAVIOUR METHODS ##

        private void Awake()
        {
            SpawnPoints = _spawnPoints;
        }

        private void Start()
        {
            List<string> _scenesToAddList = new List<string>();

            if(_loadAudio)
                _scenesToAddList.Add(Scenes.AUDIO);

            if(_loadUI)
                _scenesToAddList.Add(Scenes.UI);

            if(_loadMain)    
                _scenesToAddList.Add(Scenes.MAIN);

            if(_loadDebugUI)    
                _scenesToAddList.Add(Scenes.DEBUG_UI);

            LoadSceneJob.All(out List<LoadSceneJob> jobList, _scenesToAddList.ToArray(), true);
        }

#endregion

    }
}
