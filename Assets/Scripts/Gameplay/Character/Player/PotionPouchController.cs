/*
    Copyright (C) 2020 Team Triple Double, Diego Castagne
*/
using UnityEngine;

namespace Afloat
{
    public class PotionPouchController : MonoBehaviour
    {
        // ## UNITY EDITOR ##
        [SerializeField] private PotionPouch _pouch = null;
        [SerializeField] private PotionType[] _possiblePotionTypes = null;
        [SerializeField] private int _startingSize = 32;
        // ## PROPERTIES  ##
        // ## PUBLIC VARS ##
        // ## PROTECTED VARS ##
        // ## PRIVATE UTIL VARS ##

#region // ## MONOBEHAVIOUR METHODS ##

        private void Awake()
        {
            _pouch.Content.Clear();
            _pouch.PotionInHandIndex = 0;

            for(int count = 0; count < _startingSize; count++)
            {
                _pouch.Content.Add(_possiblePotionTypes[Random.Range(0, (_possiblePotionTypes.Length * _possiblePotionTypes.Length))  % _possiblePotionTypes.Length]);
            }

        }

#endregion

#region // ## PUBLIC METHODS ##

        public PotionType GetNextPotionType()
        {
            int temp = _pouch.PotionInHandIndex;
            _pouch.PotionInHandIndex = (_pouch.PotionInHandIndex + 1) % _pouch.Content.Count;
            return _pouch.Content[temp];
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
