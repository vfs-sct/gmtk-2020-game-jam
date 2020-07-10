/*
    Copyright (C) 2020 Team Triple Double, Sabastian Peters
*/
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Afloat.Util.SceneManagement
{
    public static class Scenes
    {
        private const string PATH_PREFIX = "Scenes/";


        public const string UI = PATH_PREFIX + "SHARED/[Scene] - Gameplay UI";
        public const string MAIN = PATH_PREFIX + "SHARED/[Scene] - Gameplay Player";
        public const string AUDIO = PATH_PREFIX + "SHARED/[Scene] - Gameplay Audio";
        public const string DEBUG_UI = PATH_PREFIX + "SHARED/[Scene] - Gameplay Debug UI";

        public const string CITY_TUTORIAL = PATH_PREFIX + "LEVEL/[Scene] - City - Tutorial";
        public const string CITY_SECTION_1 = PATH_PREFIX + "LEVEL/[Scene] - City - Section 1";
        public const string CITY_SECTION_2 = PATH_PREFIX + "LEVEL/[Scene] - City - Section 2";
        public const string CITY_SECTION_3 = PATH_PREFIX + "LEVEL/[Scene] - City - Section 3";
    }
}
