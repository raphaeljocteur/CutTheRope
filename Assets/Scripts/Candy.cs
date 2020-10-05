using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candy : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Mathf.Abs(transform.position.y) > 8)
        {
            ScenesManager.instance.Reload();
        }
	}

}
