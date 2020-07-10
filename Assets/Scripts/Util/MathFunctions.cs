
/*
    Copyright (C) 2020 Team Triple Double, Sabastian Peters
*/

using UnityEngine;

namespace Afloat.Util
{
    /*
        Class: MathFunctions

        A static util class for additional Math functions we need
    */
    public static class MathFunctions
    {

#region // ## PUBLIC METHODS ##
        
        // Function: MapFloat
        // Re-maps an float from an old range to a new range
        public static float Map (this float value, float fromLow, float fromHigh, float toLow, float toHigh) { return MapFloat(value, fromLow, fromHigh, toLow, toHigh); }
        public static float MapFloat (float value, float fromLow, float fromHigh, float toLow, float toHigh)
        {
            return (value - fromLow) * (toHigh - toLow) / (fromHigh - fromLow) + toLow;
        }

        // Function: MapInt
        // Re-maps an int from an old range to a new range
        // thanks: https://stackoverflow.com/questions/14353485/how-do-i-map-numbers-in-c-sharp-like-with-map-in-arduino
        public static int Map (this int value, int fromLow, int fromHigh, int toLow, int toHigh) { return MapInt(value, fromLow, fromHigh, toLow, toHigh); }
        public static int MapInt (int value, int fromLow, int fromHigh, int toLow, int toHigh)
        {
            return (value - fromLow) * (toHigh - toLow) / (fromHigh - fromLow) + toLow;
        }
        
        public static Vector2 MapToCircle(float x, float y)
        {
            return new Vector2(x * Mathf.Sqrt(1 - y * y / 2), y * Mathf.Sqrt(1 - x * x / 2));
        }
        
#endregion       

#region // ## PRIVATE METHODS ##   
        

        
#endregion

    }
}