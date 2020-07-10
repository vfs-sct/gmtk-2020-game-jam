
/*
    Copyright (C) 2020 Team Triple Double, Sabastian Peters
*/

using UnityEngine;

namespace Afloat 
{
    /*
        Class: FloatVariable
    */
    [CreateAssetMenu(menuName="Custom/Variable/Float")] 
    public class FloatVariable : ScriptableVariable<float>
    {

        public void ChangeBy (float amount)
        {
            Value += amount;
        }

    }
}