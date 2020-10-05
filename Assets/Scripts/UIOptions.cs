using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIOptions : MonoBehaviour
{

    [SerializeField] Image sfx, music;

    public void SwitchSfx()
    {
        Color tmp = sfx.color;
        if (tmp.a > 0.75f) tmp.a = 0.5f;
        else tmp.a = 1.0f;
        sfx.color = tmp;
    }

    public void SwitchMusic()
    {
        Color tmp = music.color;
        if (tmp.a > 0.75f) tmp.a = 0.5f;
        else tmp.a = 1.0f;
        music.color = tmp;
    }
}
