using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataManager : MonoBehaviour
{

    static DataManager instance = null;

    public int maxLvl = 0;
    public int[] lvlScore = new int[10];

    // Use this for initialization
    void Awake()
    {
        if (instance == null)
        {
            LoadPlayerProgress();
            SavePlayerProgress();
            SceneManager.LoadScene("menu");
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public static int GetMaxLvl()
    {
        return instance.maxLvl;
    }

    public static int GetLvlScore(int lvl)
    {
        return instance.lvlScore[lvl];
    }

    public static void SubmitNewPlayerScore(int lvl, int nbStar)
    {
        if (nbStar > instance.lvlScore[lvl])
        {
            instance.lvlScore[lvl] = nbStar;
            if (lvl >= instance.maxLvl) instance.maxLvl = lvl+1;
            instance.SavePlayerProgress();
        }
    }

    public void Reset()
    {
        for (int i = 0; i < 10; i++)
        {
            instance.lvlScore[i] =  0;
        }
        instance.maxLvl = 0;
        instance.SavePlayerProgress();
    }

    private void LoadPlayerProgress()
    {
        for (int i = 0; i < 10; i++)
        {
            lvlScore[i] = PlayerPrefs.GetInt("lvl" + i, 0);
        }
        maxLvl = PlayerPrefs.GetInt("maxlvl", 0);
    }

    private void SavePlayerProgress()
    {
        for(int i=0;i<10;i++)
        {
            PlayerPrefs.SetInt("lvl"+i, lvlScore[i]);
        }
        PlayerPrefs.SetInt("maxlvl", maxLvl);
    }

}