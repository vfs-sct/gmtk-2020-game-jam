/*
    Copyright (C) 2020 Team Triple Double, Diego Castagne
*/
using System.Collections.Generic;
using UnityEngine;

namespace Afloat
{
    [CreateAssetMenu( fileName = "PotionPouch", menuName = "Custom/Potions/Pouch" )]
    public class PotionPouch : ScriptableObject
    {
        public int PotionInHandIndex;
        public List<PotionType> Content;
        
        
        public PotionType CurrentPotion => Content[PotionInHandIndex];
    }
}
