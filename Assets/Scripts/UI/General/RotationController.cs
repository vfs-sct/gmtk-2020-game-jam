
/*
    Copyright (C) 2020 Team Triple Double - Sabastian Peters, J. Vitor Brito
*/

using UnityEngine;


namespace Afloat.UI
{
    /*
        Class: RotationController

        Simple controller to rotate an object at a fixed pace
    */
    public class RotationController : MonoBehaviour
    {

        // ## UNITY EDITOR ##
        
        [SerializeField] private float _rotationSpeed;
        [SerializeField] private bool _rotateX = false;
        [SerializeField] private bool _rotateY = false;
        [SerializeField] private bool _rotateZ = false;
        
        
        // ## MONOBEHAVIOUR METHODS ##
        
        private void Update()
        {
            float speed = _rotationSpeed * Time.deltaTime;

            if(_rotateX)
            {
                transform.rotation *= Quaternion.AngleAxis(speed, Vector3.right);
            }
            if(_rotateY)
            {
                transform.rotation *= Quaternion.AngleAxis(speed, Vector3.up);
            }
            if(_rotateZ)
            {
                transform.rotation *= Quaternion.AngleAxis(speed, Vector3.forward);
            }
        }
    }
}
