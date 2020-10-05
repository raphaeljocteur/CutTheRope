using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anchor : MonoBehaviour
{

    [SerializeField] bool autoSize = true;
    [SerializeField] float size = 0.0f;

    // Use this for initialization
    void Start ()
    {
        Vector3 position = transform.position;
        if(autoSize)
        { 
            Vector3 candyPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
            size = (position - candyPosition).magnitude;
        }
        RopeManager.Add(gameObject, size);
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

}
