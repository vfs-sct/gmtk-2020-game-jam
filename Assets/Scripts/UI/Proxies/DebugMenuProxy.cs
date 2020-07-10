
/*
    Copyright (C) 2020 Team Triple Double, Sabastian Peters
*/

using Afloat.Events;
using UnityEngine;

namespace Afloat.UI.Proxies
{
    /*
        Class: DebugMenuProxy
    */
    public class DebugMenuProxy : MonoBehaviour
    {
        [SerializeField] private GameEvent _onDebugPlayerTeleport;
        [SerializeField] private GameEvent _onDebugPlayerRespawn;
        [SerializeField] private GameEvent _onDebugWinningCondition;
        [SerializeField] private GameEvent _onDebugToggleFreeCam;

#region // ## PUBLIC METHODS ##
        
        // make these events?

        public void RespawnPlayer ()
        {
            Debug.Log($"DEBUG: Respawn player");
            _onDebugPlayerRespawn.Raise();
        }

        public void Teleport()
        {
            Debug.Log($"DEBUG: Player has been teleported");
            _onDebugPlayerTeleport.Raise();
        }

        public void Win ()
        {
            Debug.Log($"DEBUG: Fill player energy");
            _onDebugWinningCondition.Raise();
        }

        public void ToggleFreeCam ()
        {
            _onDebugToggleFreeCam.Raise();
        }

#endregion       

    }
}