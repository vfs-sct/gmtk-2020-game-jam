/*
    Copyright (C) 2020 Team Triple Double, Diego Castagne
*/
using UnityEngine;

namespace Afloat
{
    [CreateAssetMenu( fileName = "PotionType", menuName = "Custom/Potions/PotionType" )]
    public class PotionType : ScriptableObject
    {
        public string Name;
        public GameObject PotionPrefab;
        public GameObject VFXPrefab;
    }
}
