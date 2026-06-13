using System;
using UnityEngine;

public class Torch : MonoBehaviour
{
    [SerializeField] private GameObject light;
    
    public GameObject LightObject => light;
    public bool IsLit { get; private set; }


    
    

    public void Light()
    {
        IsLit = true;
        light?.SetActive(true);
    }
}
