/*
    Copyright (C) Team Tripple Double, Vitor Brito 2020
*/
using System.Collections.Generic;
using UnityEngine;

namespace Afloat.Events
{
    [CreateAssetMenu(menuName="Custom/Event/GameEvent")]
    public class GameEvent : ScriptableObject
    {   
        [SerializeField] private List<GameEventListenerController> listeners = new List<GameEventListenerController>();

        public void Raise()
        {
            for (int i = listeners.Count - 1; i >= 0 ; i--)
            {
                listeners[i].OnEventRaised();
            }
        }

        public void RegisterListener(GameEventListenerController listener)
        {
            listeners.Add(listener);
        }

        public void UnregisterListener(GameEventListenerController listener)
        {
            listeners.Remove(listener);
        }
    }
}
