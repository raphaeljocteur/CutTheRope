using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LvlButton : MonoBehaviour
{

    Button btn;
    [SerializeField] int lvl;

    [SerializeField] Image stars, stars1, stars2, stars3, on, off;
    [SerializeField] Text text;
    // Use this for initialization
    void Awake()
    {
        btn = GetComponent<Button>();
    }

    void Start()
    {
        if (DataManager.GetMaxLvl() < lvl)
        {
            on.enabled = false;
            off.enabled = true;
            text.enabled = false;
            btn.interactable = false;
        }
        else
        {
            on.enabled = true;
            off.enabled = false;
            btn.interactable = true;
            switch(DataManager.GetLvlScore(lvl))
            {
                case 0:
                    stars.enabled = true;
                    break;
                case 1:
                    stars1.enabled = true;
                    break;
                case 2:
                    stars2.enabled = true;
                    break;
                case 3:
                    stars3.enabled = true;
                    break;
                default:
                    break;
            }
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
