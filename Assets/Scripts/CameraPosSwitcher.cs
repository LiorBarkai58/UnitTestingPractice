using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class CameraPosSwitcher : MonoBehaviour
    {

        private Camera _cam;

        private void Awake()
        {
            _cam = Camera.main;
        }

        public void MoveCamera()
        {
            if (_cam)
            {
                _cam.transform.position = transform.position;
                _cam.transform.rotation = transform.rotation;
            }
        }
    }
}