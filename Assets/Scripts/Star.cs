using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{

    bool hit = false;
    [SerializeField] GameObject[] AudioStarPrefab;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!hit && collision.gameObject.CompareTag("Player"))
        {
            hit = true;
            LvlManager.AddStar();
            int i = Random.Range(0, 3);
            Instantiate(AudioStarPrefab[i]);
            Destroy(gameObject);
        }
    }
}
