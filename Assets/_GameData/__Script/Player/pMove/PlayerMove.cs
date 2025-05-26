using UnityEngine;

namespace Player.pMove
{
    public class PlayerMove : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 3f;
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

        private Vector3 MoveDirection(Vector3 inputMoveDir)
        {
            float finalSpeed = moveSpeed * Mathf.Clamp01(inputMoveDir.magnitude);
            
            return inputMoveDir.normalized * finalSpeed;
        }
    }
}
