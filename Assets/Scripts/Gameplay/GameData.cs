/*
    Copyright (C) 2020 Team Triple Double, Diego Castagne
*/
using UnityEngine;

namespace Afloat
{
    [CreateAssetMenu( fileName = "GameData", menuName = "Custom/Gameplay/GameData" )]
    public class GameData : ScriptableObject
    {
        public float TimeSurvived;
        public int LivesLeft;
        public int RedGoblinsKilled;
        public int GreenGoblinsKilled;
        public int BlueGoblinsKilled;

        public int MaxGoblins;
        public int CurrentGoblins;

        public int TotalGoblinsKilled => RedGoblinsKilled + GreenGoblinsKilled + BlueGoblinsKilled;
    }
}
