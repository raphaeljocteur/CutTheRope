using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulle : MonoBehaviour
{

    GameObject child;
    CircleCollider2D cc;
    float time = 0.0f;

    [SerializeField] GameObject AudioBullePrefab;


    // Use this for initialization
    void Awake ()
    {
        cc = GetComponent<CircleCollider2D>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (child)
        {
            Vector3 Velocity = child.GetComponent<Rigidbody2D>().velocity;
            child.GetComponent<Rigidbody2D>().velocity = new Vector3(0, (time-0.5f) * 5.0f, 0);
            transform.position = child.transform.position;
            time += Time.deltaTime;
            if (time > 1.5f) time = 1.5f;

            if (Input.GetMouseButtonDown(0))
            {
                Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                if (cc.OverlapPoint(mousePosition))
                {
                    child.GetComponent<Rigidbody2D>().gravityScale = 1;
                    child = null;
                    Instantiate(AudioBullePrefab);
                    Destroy(gameObject);
                }
            }

        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            child = collision.gameObject;
            child.GetComponent<Rigidbody2D>().velocity = new Vector3(0, -1.0f, 0);
            child.GetComponent<Rigidbody2D>().gravityScale = 0;
        }
        if (collision.gameObject.tag == "Pique")
        {
            child.GetComponent<Rigidbody2D>().gravityScale = 1;
            child = null;
            Instantiate(AudioBullePrefab);
            Destroy(gameObject);
        }
    }

}
