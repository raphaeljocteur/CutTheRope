using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{

    public static ScenesManager instance = null;

    // Use this for initialization
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void Load(string name)
    {
        SoundManager.StopAll();
        SceneManager.LoadScene(name);
    }

    public static int GetCurrentIndex()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }

    public void Next()
    {
        SoundManager.StopAll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

    public void Reload()
    {
        SoundManager.StopAll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Exit()
    {
        SoundManager.StopAll();
        Application.Quit();
    }

}
