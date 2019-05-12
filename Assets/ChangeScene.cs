using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    private List<string> _scenesNames = new List<string>() {"A", "B"};

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            int currentScene = _scenesNames.FindIndex(s => s == SceneManager.GetActiveScene().name);
            if (++currentScene >= _scenesNames.Count)
            {
                currentScene = 0;
            }
            SceneManager.LoadScene(_scenesNames[currentScene]);
        }
    }
}
