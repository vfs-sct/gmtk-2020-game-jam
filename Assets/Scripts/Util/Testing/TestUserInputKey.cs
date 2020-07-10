
/*
    Copyright (C) 2020 Team Triple Double, Sabastian Peters

    Data for detecting a single input from the User
*/

using UnityEngine;
using UnityEngine.Events;

namespace Afloat.Util.Testing
{
    [System.Serializable]
    public class TestUserInputKey 
    {
        public KeyCode KeyCode;
        public UnityEvent OnKeyDown;
        public UnityEvent OnKeyHeld;
        public UnityEvent OnKeyUp;
    }
}