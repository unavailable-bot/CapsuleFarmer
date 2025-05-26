using System;
using UnityEngine;

namespace Characters.Dragon.dMove
{
    public class DragonMove : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 3f;
        private Rigidbody _rb;
        private Transform _playerTarget;

        private void Start()
        {
            _rb = GetComponent<Rigidbody>();
            _playerTarget = GameObject.Find("Player").transform;
        }
        
        private void FixedUpdate()
        {
            _rb.MovePosition(MoveDirection());
        }

        private void Update()
        {
            LookAt(_playerTarget);
        }

        private Vector3 MoveDirection()
        {
            Vector3 dir = (_playerTarget.position - this.transform.position).normalized;
            return this.transform.position + dir * (moveSpeed * Time.fixedDeltaTime);
        }

        private void LookAt(Transform target)
        {
            Vector3 lookDir = target.position - this.transform.position;
            lookDir.y = 0f;
            if (lookDir != Vector3.zero)
                this.transform.rotation = Quaternion.LookRotation(lookDir);
        }
    }
}
