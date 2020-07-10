
/*
    Copyright (C) 2020 Team Triple Double, Sabastian Peters
*/

using System.Collections;
using UnityEngine;

namespace Afloat.Util.Coroutines 
{
    // Class: CoroutineHandler
    public class CoroutineHandler
    {
        
        // ## PROPERTIES ##
        
        public bool IsRunning => _routine != null;

        // ## PUBLIC VARS ##
        
        public CoroutineHandlerParams Params;
        
        // ## PROTECTED VARS ##
        
        
        // ## PRIVATE UTIL VARS ##
        
        [SerializeField] private Coroutine _routine;



        // ## CONSTRUCTOR ##

        // Function: Constructor
        // Takes in a target to run coroutines on
        public CoroutineHandler(MonoBehaviour target)
        {
            Params = new CoroutineHandlerParams()
            {
                Target = target
            };
        }

        public CoroutineHandler(CoroutineHandlerParams parameters)
        {
            Params = parameters;
        }

              

#region // ## PUBLIC METHODS ##

        public void Start (IEnumerator routine)
        {
            StartCoroutine(routine);
        }

        // Function: Start
        // Starts the coroutine
        public void Stop ()
        {
            StopCoroutine(_routine);
        }


#endregion       
        
#region // ## PRIVATE METHODS ##   
        
        // Function: StartCoroutne
        // proxy method for starting a coroutine on target gameobject
        // stops the current routine if there is one & starts the new one
        private Coroutine StartCoroutine (IEnumerator routine)
        {
            if(_routine != null) StopCoroutine(_routine);
            return _routine = Params.Target.StartCoroutine(StartCoroutineRoutine(routine));
        }

        // Function: StartCoroutne
        // proxy method for stopping a coroutine on target gameobject
        private void StopCoroutine (Coroutine routine)
        {
            if(routine != null) Params.Target.StopCoroutine(routine);
            _routine = null;
        }


        // Function: StartCoroutineRoutine
        // a routine to start a coroutine
        // runs the coroutine. when done, the reference to the routine will be null
        private IEnumerator StartCoroutineRoutine (IEnumerator routine)
        {
            yield return routine;
            _routine = null;
        }
        
#endregion

    }
}