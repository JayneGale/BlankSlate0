using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour
{
    public int nextScene = 1;
    public bool testMode = true;
    public bool gotSignal = false;


    // Start is called before the first frame update
    void Start()
    {
        // print("IntroManager.Start()");

        //var scenes = new List<Scene>();
        //var sceneCount = SceneManager.sceneCount;
        //for (var i = 0; i < sceneCount; i++)
        //{
        //    var scene = SceneManager.GetSceneAt(i);
        //    scenes.Add(scene);
        //    print($"Scene {i} is \"{scene.name}\"");
        //}
        
    }

    public void LoadNewScene()
    {
        gotSignal = true;

        print("LoadNewScene() called");

        if (testMode)
        {
            print("..just testing.  No new scene loaded.");
        }
        else
        {
            SceneManager.LoadScene(nextScene);      // currently [0] is the main scene
        }
    }
}
