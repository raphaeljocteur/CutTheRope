using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailManager : MonoBehaviour
{
    Vector3 tmp;
    TrailRenderer tr;

    static TrailManager instance = null;

    // Use this for initialization
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            tr = GetComponent<TrailRenderer>();
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update ()
    {

        if (Input.GetMouseButton(0)) tr.enabled = true;
        else tr.enabled = false;

        tmp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        tmp.z = 0;
        transform.position = tmp;

    }
}
