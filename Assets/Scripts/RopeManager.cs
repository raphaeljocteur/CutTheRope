using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeManager : MonoBehaviour
{

    static RopeManager instance;
    GameObject candy;

    List<Rope> ropes;
    Vector3 beginMousePosition;
    Vector3 endMousePosition;
    Vector3[] points;

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
        candy = GameObject.FindGameObjectWithTag("Player");
    }

    // Use this for initialization
    void Start ()
    {
        ropes = new List<Rope>();
    }

    public static void Add(GameObject a, float length)
    {
        Rope tmp = new Rope(a.transform.position, instance.candy.transform.position, length);
        tmp.SetAnchor(a.GetComponent<Rigidbody2D>());
        tmp.SetWeight(instance.candy);
        instance.ropes.Add(tmp);
    }

    // Update is called once per frame
    void Update ()
    {
        for(int i =0; i < ropes.Count;++i)
        {
            ropes[i].Update();
        }
        if (Input.GetMouseButtonDown(0))
        {
            beginMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        else if(Input.GetMouseButton(0))
        {
            endMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D[] hits = Physics2D.RaycastAll(beginMousePosition, endMousePosition - beginMousePosition, (endMousePosition - beginMousePosition).magnitude);

            Debug.DrawRay(beginMousePosition, endMousePosition - beginMousePosition, Color.yellow, 5.0f);
            foreach (RaycastHit2D hit in hits)
            {
                if(hit.collider.name=="Rope")
                {
                    int index = -1;
                    int i = 0;
                    foreach (Rope rope in ropes)
                    {
                        if (rope.EdgeCollider == hit.collider)
                        {
                            index = i;
                            rope.Cut();
                        }
                        i++;
                    }
                    ropes.RemoveAt(index);
                    Destroy(hit.collider.gameObject);
                }
                
            }
            beginMousePosition = endMousePosition;
        }
    }
}