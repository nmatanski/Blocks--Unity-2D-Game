using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField]
    private int breakableBlocks; //use in Inspector only in Debug mode

    //cached component refs
    SceneLoader sceneLoader;

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    public void IncrementBreakableBlocks()
    {
        breakableBlocks++;
    }

    public void OnBlockDestroy()
    {
        breakableBlocks--;
        if (breakableBlocks <= 0)
        {
            sceneLoader.LoadNextScene();
        }
    }

}
