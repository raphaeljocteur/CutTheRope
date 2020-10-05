using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicAnchor : MonoBehaviour
{

    bool isUsed = false;
    [SerializeField] float length;
    [SerializeField] GameObject circle;
    CircleCollider2D cc;
    float time;

    void Awake()
    {
        cc = GetComponent<CircleCollider2D>();
    }

    // Use this for initialization
    void Start ()
    {
        Vector3 scale = circle.transform.localScale;
        scale.x = cc.radius;
        scale.y = cc.radius;
        circle.transform.localScale = scale;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !isUsed)
        {
            isUsed = true;
            RopeManager.Add(gameObject, length);
        }
    }
}
