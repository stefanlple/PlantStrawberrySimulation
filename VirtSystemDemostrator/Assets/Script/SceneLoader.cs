using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadingSceneById(int i)
    {
        SceneManager.LoadScene(i);
    }
    public void LoadingSceneByName(string i)
    {
        SceneManager.LoadScene(i);
    }
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void quitApplication()
    {
        Application.Quit();
    }

}
