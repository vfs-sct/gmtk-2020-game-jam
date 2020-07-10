
/*
    Copyright (C) 2020 Team Triple Double, Sabastian Peters
*/

using UnityEngine;

namespace Afloat
{

    // TODO: convert this to a scriptable variable. First talk to Vitor & Diego about how to do this

    [CreateAssetMenu(menuName="Custom/Variable/LayerMask")] 
    public class LayerMaskVariable : ScriptableVariable<LayerMask>
    {

#region // ## PUBLIC METHODS ##

        // Function: Contains
        // Returns if the provided layer exists in the layer mask
        public bool Contains (int layer)
        {
            /// if our layer mask doesn't change when we add the provided layer, our layer mask contains it
            return Value == (Value | (1 << layer));
        }

#endregion

    }
}