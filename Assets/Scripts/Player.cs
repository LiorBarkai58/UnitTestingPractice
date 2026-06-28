using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace DefaultNamespace
{
    public class Player: MonoBehaviour
    {
        [SerializeField] private Rigidbody rb;
        [SerializeField] private float speed;

        private Vector2 moveDirection;

        private void FixedUpdate()
        {
            Vector3 calculatedSpeed = moveDirection * (speed * Time.fixedDeltaTime);
            rb.MovePosition(rb.position + new Vector3(calculatedSpeed.x, 0, calculatedSpeed.y));
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            moveDirection = context.ReadValue<Vector2>();
        }
    }
}