
/*
    Copyright (C) 2020 Team Triple Double, Sabastian Peters
*/

using UnityEngine;
using System.Collections;


namespace Afloat.UI
{
    /*
        Class: TransitionUI
    */
    public class TransitionUI : MonoBehaviour
    {
        
        private const string TRANSITION_OUT_STATE_NAME = "Transition Out From Game";
        private const string TRANSITION_IN_STATE_NAME = "Transition Into Game";
        private const int ANIM_LAYER = 0;

        // ## UNITY EDITOR ##

        [SerializeField] private Animator _transitionAnimator = null;
        
        
        // ## PROPERTIES  ##
        
        
        // ## PUBLIC VARS ##
        
        
        // ## PROTECTED VARS ##
        
        
        // ## PRIVATE UTIL VARS ##
        


              
#region // ## MONOBEHAVIOUR METHODS ##
        
        
#endregion      

#region // ## PUBLIC METHODS ##
        
        
        // Function: TransitionOut
        // Fades out of gameplay into the transition screen.
        // Think of it like a show method.
        public IEnumerator TransitionOut ()
        {
            _transitionAnimator.Play(TRANSITION_OUT_STATE_NAME, ANIM_LAYER);
            
            // wait for length of anim
            yield return new WaitForSeconds(
                _transitionAnimator.GetCurrentAnimatorStateInfo(0).length
            );
        }

        // Function: TransitionIn
        // Fades into gameplay from the transition screen.
        // Think of it like a hide method.
        public IEnumerator TransitionIn ()
        {
            _transitionAnimator.Play(TRANSITION_IN_STATE_NAME, ANIM_LAYER);

            // wait for length of anim
            yield return new WaitForSeconds(
                _transitionAnimator.GetCurrentAnimatorStateInfo(0).length +
                _transitionAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime
            );
        }



#endregion       

#region // ## <SOME INTERFACE> METHODS ##   
        

        
#endregion
        
#region // ## PROTECTED METHODS ##   
        

        
#endregion
        
#region // ## PRIVATE METHODS ##   
        

        
#endregion

    }
}