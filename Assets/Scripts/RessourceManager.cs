using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RessourceManager : MonoBehaviour
{

    static RessourceManager instance = null;

    [SerializeField] Material ropeMaterial;
    [SerializeField] GameObject[] AudioRopePrefab;

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

    // Update is called once per frame
    public static GameObject GetRopeAudio()
    {
        int i = Random.Range(0, 3);
        return instance.AudioRopePrefab[i];
    }

    // Update is called once per frame
    public static Material GetRopeMaterial()
    {
        return instance.ropeMaterial;
	}

}
