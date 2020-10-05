
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScore : MonoBehaviour
{

    [SerializeField] Image star1, star2, star3;

    public void SetStar(int nbStar)
    {
        if (nbStar > 0) star1.enabled = true;
        if (nbStar > 1) star2.enabled = true;
        if (nbStar > 2) star3.enabled = true;
    }
}