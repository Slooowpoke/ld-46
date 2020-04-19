using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsCollidingWithGoal : MonoBehaviour
{
    public GameObject levelLoader;
    LevelLoaderTest levelLoaderScript;

    void Start()
    {
        levelLoaderScript = (LevelLoaderTest)levelLoader.GetComponent(typeof(LevelLoaderTest));
    }

    void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.tag == "goal")
        {
            Debug.Log("Level Complete");
            levelLoaderScript.LoadNextLevel();
        }
    }

}
