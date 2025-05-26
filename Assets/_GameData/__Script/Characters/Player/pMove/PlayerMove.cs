using System;
using UnityEngine;

namespace Characters.Player.pMove
{
    public class PlayerMove : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 3f;
        [SerializeField] private float sensitivity = 3;
        private Rigidbody _rb;

        private Vector3 _moveDir;

        private void Start()
        {
            _rb = GetComponent<Rigidbody>();
        }
        
        private void Update()
        {
            float inputX = Input.GetAxis("Horizontal");
            float inputZ = Input.GetAxis("Vertical");
            
            _moveDir = new Vector3(inputX, 0f, inputZ);
        }

        private void FixedUpdate()
        {
            _rb.linearVelocity = transform.TransformDirection(MoveDirection(_moveDir));;
        }

        private void LateUpdate()
        {
            float mouseX = Input.GetAxis("Mouse X") * sensitivity;
            PlayerRotation(mouseX);
        }

        private Vector3 MoveDirection(Vector3 inputMoveDir)
        {
            float finalSpeed = moveSpeed * Mathf.Clamp01(inputMoveDir.magnitude);
            
            return inputMoveDir.normalized * finalSpeed;
        }
        
        private void PlayerRotation(float mouseX)
        {
            this.transform.Rotate(Vector3.up * mouseX);
        }
    }
}
