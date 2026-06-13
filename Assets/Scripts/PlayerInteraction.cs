using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace DefaultNamespace
{
    public class PlayerInteraction : MonoBehaviour
    {
        private Torch torchInRange;
        [SerializeField] private string tagToCheck = "Torch";
        public string TagToCheck => tagToCheck;
        public void OnInteract(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                LightTorch();
                Debug.Log("Light Torch");
            }
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(tagToCheck))
            {
                Torch torch = other.GetComponent<Torch>();
                if(torch) torchInRange = torch;
            }
        }
        
        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Torch"))
            {
                Torch torch = other.GetComponent<Torch>();
                if(torch && torch == torchInRange) torchInRange = null;
            }
        }

        public void LightTorch()
        {
            if (torchInRange) torchInRange.Light();
        }
    }
}