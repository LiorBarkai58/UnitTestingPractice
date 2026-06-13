using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class UnitTests
{
    // A Test behaves as an ordinary method
    [Test]
    public void CheckTorchFunction()
    {
        GameObject gameObject = new GameObject();
        Torch torch = gameObject.AddComponent<Torch>();
        
        torch.Light();
        
        Assert.IsTrue(torch.IsLit);
        
        Object.DestroyImmediate(gameObject);
    }

    
}
