using System;
using UnityEngine;

namespace Characters.Player.pMove
{
    public class PlayerCamera : MonoBehaviour
    {
        private const float zoomSpeed = 10f;
        private const float minZoom = 60f;
        private const float maxZoom = 120f;
        private const float smoothTime = 0.2f;
        private const float zoomSensitivity = 3f;
        
        private Camera _camera;
        private float targetFOV;
        private float currentVelocity;
        
        private void Start()
        {
            _camera = GetComponent<Camera>();
            _camera.fieldOfView = 90f;
            targetFOV = _camera.fieldOfView;
            
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        private void LateUpdate()
        {
            float scroll = Input.GetAxis("Mouse ScrollWheel") * zoomSensitivity;

            if (scroll != 0)
            {
                targetFOV -= scroll * zoomSpeed;
                targetFOV = Mathf.Clamp(targetFOV, minZoom, maxZoom);
            }
            
            _camera.fieldOfView = Mathf.SmoothDamp(_camera.fieldOfView, targetFOV, ref currentVelocity, smoothTime);
        }
    }
}
