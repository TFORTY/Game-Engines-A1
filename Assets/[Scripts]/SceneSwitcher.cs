using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    // Switches scenes 
    public void SceneSwitch(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}