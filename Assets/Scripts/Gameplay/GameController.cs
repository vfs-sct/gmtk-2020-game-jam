/*
    Copyright (C) 2020 Team Triple Double, Diego Castagne
*/
using Afloat.Events;
using UnityEngine;

namespace Afloat
{
    public class GameController : MonoBehaviour
    {
        // ## UNITY EDITOR ##
        [SerializeField] private GameData _data = null;
        [SerializeField] private int _startingLives;
        [SerializeField] private GameEvent _gameOverEvent;
        [SerializeField] private Transform[] _goblinsSpawnPoints = null;
        [SerializeField] private GameObject[] _goblinsPrefabs = null;
        [SerializeField] private float _intervalBetweenSpawns = 5f;
        // ## PROPERTIES  ##
        // ## PUBLIC VARS ##
        // ## PROTECTED VARS ##
        // ## PRIVATE UTIL VARS ##
        private float _spawnTimer;

#region // ## MONOBEHAVIOUR METHODS ##

        private void Awake()
        {
            _data.BlueGoblinsKilled = 0;
            _data.RedGoblinsKilled = 0;
            _data.GreenGoblinsKilled = 0;

            _data.CurrentGoblins = 0;

            _data.TimeSurvived = 0f;
            _data.LivesLeft = _startingLives;

            _spawnTimer = 0f;
        }

        private void Update()
        {
            if(_data.LivesLeft <= 0)
            {
                _gameOverEvent.Raise();
            }

            if(_data.CurrentGoblins < _data.MaxGoblins)
            {
                _spawnTimer += Time.deltaTime;

                if(_spawnTimer > _intervalBetweenSpawns)
                {
                    _spawnTimer = 0f;
                    SpawnGoblinRandomly();
                }
            }
            else
            {
                _spawnTimer = 0f;
            }
        }


#endregion

#region // ## PUBLIC METHODS ##

        public void EndGame()
        {}

        public void RedGoblinDied()
        {
            _data.RedGoblinsKilled++;
            _data.CurrentGoblins--;
        }

        public void GreenGoblinDied()
        {
            _data.GreenGoblinsKilled++;
            _data.CurrentGoblins--;
        }

        public void BlueGoblinDied()
        {
            _data.BlueGoblinsKilled++;
            _data.CurrentGoblins--;
        }

        public void RegisterGoblin()
        {
            _data.CurrentGoblins++;
        }

        public void SpawnGoblinRandomly()
        {
            var goblinToSpawn = _goblinsPrefabs[Random.Range(0, _goblinsPrefabs.Length * _goblinsPrefabs.Length) % _goblinsPrefabs.Length];

            var placeToSpawnIn = _goblinsSpawnPoints[Random.Range(0, _goblinsSpawnPoints.Length * _goblinsSpawnPoints.Length) % _goblinsSpawnPoints.Length];

            Instantiate(goblinToSpawn, placeToSpawnIn.position, placeToSpawnIn.rotation);
        }


#endregion
        
#region // ## <SOME INTERFACE> METHODS ##   
#endregion

#region // ## PROTECTED METHODS ##   
#endregion
        
#region // ## PRIVATE METHODS ##   



#endregion

    }
}
