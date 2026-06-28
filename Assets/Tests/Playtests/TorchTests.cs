using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DefaultNamespace;
using NUnit.Framework;
using Unity.PerformanceTesting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;


public class TorchTests
{
    List<Torch> torches;
    private PlayerInteraction player;
    [UnitySetUp]
    public IEnumerator SetupTorchesScene()
    {
        yield return SceneManager.LoadSceneAsync("SampleScene");
        torches = Object.FindObjectsByType<Torch>(sortMode: FindObjectsSortMode.None).ToList();
        player = Object.FindFirstObjectByType<PlayerInteraction>();
        
    }
    
    [UnityTest]
    public IEnumerator CheckTorchInitializationSmokeTest()
    {
        foreach (var torch in torches)
        {
            Assert.IsFalse(torch.IsLit);
        }
        yield return null;
    }
    [UnityTest]
    public IEnumerator TorchIntegration()//Make sure all the torches can be lit up
    {
        foreach (var torch in torches)
        {
            Assert.IsFalse(torch.IsLit);
            
            torch.Light();
            Assert.IsTrue(torch.IsLit);
            Assert.IsTrue(torch.LightObject.activeSelf);
        }
        yield return null;
    }

    [UnityTest]
    public IEnumerator RegressionTestTags()
    {
        foreach (var torch in torches)
        {
            Assert.IsTrue(torch.gameObject.CompareTag(player.TagToCheck));
        }
        yield return null;
    }

    [UnityTest]
    [Performance]
    public IEnumerator FunctionalLightTorches()
    {
        foreach (Torch torch in torches)
        {
            player.transform.position = torch.transform.position;
            yield return new WaitForSeconds(0.1f);
            player.LightTorch();
            yield return new WaitForSeconds(0.1f);
            yield return Measure.Frames().SampleGroup("FPS").WarmupCount(10).MeasurementCount(30).Run();
            Assert.IsTrue(torch.IsLit);
            Assert.IsTrue(torch.LightObject.activeSelf);
            yield return new WaitForSeconds(1f);
            
            
        }

        player.transform.position = new Vector3(1000, 1000, 1000);//Teleport the player away

        foreach (Torch torch in torches)//Make sure the torches are on when moving away
        {
            Assert.IsTrue(torch.IsLit);
            Assert.IsTrue(torch.LightObject.activeSelf);
        }
    }
    
    [UnityTest]
    public IEnumerator LoadTest()
    {
        for (int i = 0; i < 70; i++)
        {
        }
        foreach (Torch torch in torches)
        {
            player.transform.position = torch.transform.position;
            yield return new WaitForSeconds(0.1f);
            player.LightTorch();
            yield return new WaitForSeconds(0.1f);
            Assert.IsTrue(torch.IsLit);
            Assert.IsTrue(torch.LightObject.activeSelf);
            yield return new WaitForSeconds(1f);
            
            
        }

        player.transform.position = new Vector3(1000, 1000, 1000);//Teleport the player away

        foreach (Torch torch in torches)//Make sure the torches are on when moving away
        {
            Assert.IsTrue(torch.IsLit);
            Assert.IsTrue(torch.LightObject.activeSelf);
        }
    }
    
    
}
