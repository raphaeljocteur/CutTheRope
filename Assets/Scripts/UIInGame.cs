using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInGame : MonoBehaviour
{

    [SerializeField] Image star1on, star2on,  star3on;
	
	public void AddStar(int nbStar)
    {
		switch(nbStar)
        {
            case 1:
                star1on.enabled = true;
                break;
            case 2:
                star2on.enabled = true;
                break;
            case 3:
                star3on.enabled = true;
                break;
        }
	}
}
