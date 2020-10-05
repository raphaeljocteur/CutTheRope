using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundEvent : MonoBehaviour
{

    [SerializeField] AudioClip source;
    [SerializeField] AudioMixerGroup group;
    [SerializeField] bool loop = false;

    // Use this for initialization
    void Start ()
    {
        SoundManager.AddSource(source, group, loop, true);
        Destroy(gameObject);
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}