using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundController : MonoBehaviour//muda as imagens dos backgrounds e os personagens, sera utilizado para controlar as animacoes;
{

    private SpriteSwitcher switcher;
    public bool isSwitched = false;
    public Image background1;
    public Image background2;
    private RectTransform rect;
    private CanvasGroup canvasGroup;


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
    public void Move(Vector2 coords, float speed, bool isAnimated = true)
    {
        if (isAnimated)
        {
            StartCoroutine(MoveCoroutine(coords, speed));
        }
        else
        {
            rect.localPosition = coords;
        }
    }

    private IEnumerator MoveCoroutine(Vector2 coords, float speed)
    {
        while (rect.localPosition.x != coords.x || rect.localPosition.y != coords.y)
        {
            rect.localPosition = Vector2.MoveTowards(rect.localPosition, coords,
                Time.deltaTime * 1000f * speed);
            yield return new WaitForSeconds(0.01f);
        }
    }

    public void SwitchSprite(Sprite sprite, bool isAnimated = true)
    {
        if (switcher.GetImage() != sprite)
        {
            if (isAnimated)
            {
                switcher.SwitchImage(sprite);
            }
            else
            {
                switcher.SetImage(sprite);
            }
        }
    }
}
