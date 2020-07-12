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
        // ## PROPERTIES  ##
        // ## PUBLIC VARS ##
        // ## PROTECTED VARS ##
        // ## PRIVATE UTIL VARS ##

#region // ## MONOBEHAVIOUR METHODS ##

        private void Awake()
        {
            _data.BlueGoblinsKilled = 0;
            _data.RedGoblinsKilled = 0;
            _data.GreenGoblinsKilled = 0;

            _data.CurrentGoblins = 0;

            _data.TimeSurvived = 0f;
            _data.LivesLeft = _startingLives;
        }

        private void Update()
        {
            if(_data.LivesLeft <= 0)
            {
                _gameOverEvent.Raise();
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


#endregion
        
#region // ## <SOME INTERFACE> METHODS ##   
#endregion

#region // ## PROTECTED METHODS ##   
#endregion
        
#region // ## PRIVATE METHODS ##   
#endregion

    }
}
