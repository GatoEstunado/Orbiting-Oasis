using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundController : MonoBehaviour //muda as imagens dos backgrounds, sera utilizado para controlar as animacoes;
{

    public bool isSwitched = false;
    public Image background1;
    public Image background2;

    public void SetImage(Sprite sprite)
    {
        if (!isSwitched)
        {
            background1.sprite = sprite;
        }
        else
        {
            background2.sprite = sprite;
        }
    }
}
