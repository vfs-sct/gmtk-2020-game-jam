
/*
    Copyright (C) 2020 Team Triple Double, Sabastian Peters
*/

using UnityEngine;

namespace Afloat
{
    /*
        Class: PotionPrefabUI
    */
    public class PotionPrefabUI : MonoBehaviour
    {
        
        // ## UNITY EDITOR ##
        
        [SerializeField] private GameObject _redPotion;
        [SerializeField] private GameObject _bluePotion;
        [SerializeField] private GameObject _greenPotion;
        [SerializeField] private PotionPouch _targetPouch;
              
#region // ## MONOBEHAVIOUR METHODS ##
                
        private void Update()
        {
            switch(_targetPouch.CurrentPotion.Name)
            {
                case "Red Potion":
                {
                    SetTargetActive(_redPotion);
                    break;
                }
                case "Green Potion":
                {
                    SetTargetActive(_greenPotion);
                    break;
                }
                default:
                case "Blue Potion":
                {
                    SetTargetActive(_bluePotion);
                    break;
                }
            }
        }
        
#endregion      
        
#region // ## PRIVATE METHODS ##   
        
        private void SetTargetActive (GameObject target)
        {
            _redPotion.SetActive(false);
            _greenPotion.SetActive(false);
            _bluePotion.SetActive(false);

            target.SetActive(true);
        }
        
#endregion

    }
}