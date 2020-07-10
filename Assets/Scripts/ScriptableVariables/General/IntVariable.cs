
/*
    Copyright (C) 2020 Team Triple Double, Sabastian Peters
*/

using UnityEngine;

namespace Afloat 
{
    /*
        Class: IntVariable
    */
    [CreateAssetMenu(menuName="Custom/Variable/Integer")] 
    public class IntVariable : ScriptableVariable<int>
    {
        public void ChangeBy (int amount)
        {
            Value += amount;
        }   
    }
}
