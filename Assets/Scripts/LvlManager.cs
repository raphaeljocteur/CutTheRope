using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LvlManager : MonoBehaviour
{

    static LvlManager instance = null;

    int nbStar = 0;
    bool victory = false;

    // Use this for initialization
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            instance.nbStar = 0;
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }


    public static void ResetStar()
    {
        instance.nbStar = 0;
    }

    public static void AddStar()
    {
        instance.nbStar++;
        GameObject.FindGameObjectWithTag("UIInGame").GetComponent<UIInGame>().AddStar(instance.nbStar);
    }

    public static int GetStar()
    {
        return instance.nbStar;
    }

    public static void Defeat()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public static void Victory()
    {
        GameObject.FindGameObjectWithTag("UIInGame").SetActive(false);
        GameObject.FindGameObjectWithTag("UIScore").transform.GetChild(0).gameObject.SetActive(true);
        GameObject.FindGameObjectWithTag("UIScore").GetComponent<UIScore>().SetStar(instance.nbStar);
        DataManager.SubmitNewPlayerScore(SceneManager.GetActiveScene().buildIndex, instance.nbStar);
        ResetStar();
    }

}
