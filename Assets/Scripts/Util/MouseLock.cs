
/*
    Copyright (C) 2020 Team Triple Double, Sabastian Peters
*/

using UnityEngine;

namespace Afloat.Util
{
    /*
        Class: MouseLock
    */
    public static class MouseLock
    {


        // ## PRIVATE UTIL VARS ##
        
        private static int _lockCount = 0;


#region // ## PUBLIC METHODS ##
                
        public static void TryLock ()
        {
            Lock();
            return;

            _lockCount = Mathf.Max(0, _lockCount - 1); /// locked is default state

            if(_lockCount == 0)
            {
                Lock();
            }
        }

        public static void TryUnlock ()
        {
            Unlock();
            return;

            _lockCount++;

            if(_lockCount == 1)
            {
                Unlock();
            }
        }
        
#endregion       


#region // ## PRIVATE UTIL METHODS ##
                
        private static void Lock ()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        private static void Unlock ()
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        
#endregion

    }
}