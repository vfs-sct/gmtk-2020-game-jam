
/*
    Copyright (C) 2020 Team Triple Double, Sabastian Peters
*/

using UnityEngine;

namespace Afloat
{
    /*
        Class: IPlayerPrefsVariable

        An interface that can tell a player pref variable to load its data.
        Used by <PlayerPrefsInitializeController>.
    */
    public interface IPlayerPrefsVariable
    {
        void Load ();
    }
}