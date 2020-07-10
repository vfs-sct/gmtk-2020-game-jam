
/*
    Copyright (C) 2020 Team Triple Double, Sabastian Peters
*/

using UnityEngine;


namespace Afloat 
{
    public class ScriptableVariable : ScriptableObject {}
    public class ScriptableVariable<T> : ScriptableVariable, ISerializationCallbackReceiver
    {
        
        [SerializeField] private T _value; /// the start value
        public virtual T Value { get; set; }


#region // ## PUBLIC METHODS ##

        public virtual void SetTo (T newValue)
        {
            Value = newValue;
        }
        
#endregion

#region // ## SERIALIZATION INTERFACE METHODS ##

        // Function: OnAfterDeserialize
        // This is run everytime the value is changed in the inspector
        public virtual void OnAfterDeserialize ()
        {
            Value = _value;
        }

        public virtual void OnBeforeSerialize() 
        {

        }

#endregion

#region // ## CONVERSION OPERATORS ##

        // implicitly coverts from Scriptable Variable to runtime value
        public static implicit operator T(ScriptableVariable<T> variable) => variable.Value;


        // explicit and implicit conversion to string
        public override string ToString()
        {
            return Value.ToString();
        }

#endregion


#region // ## PROTECTED METHODS ##

        public virtual T GetInspectorValue ()
        {
            return _value;
        }
        
#endregion

    }
}

