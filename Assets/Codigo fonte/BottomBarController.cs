using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BottomBarController : MonoBehaviour //codigo controlador da barra de dialogos adicionar na barra
{
    public TextMeshProUGUI barText;
    public TextMeshProUGUI personNameText;

    private int sentenceIndex = -1;
    private StoryScene currentScene;
    private State state = State.COMPLETED;
    private bool isHidden = false;//ira esconder a barra 

    private enum State//enumera estados posiveis
    {
        PLAYING, COMPLETED
    }


    public void Hide()//esconde a barra
    {
        if (!isHidden)
        {
            isHidden = true;
        }
    }

    public void Show()//mosta a barra
    {
        isHidden = false;
    }

    public void ClearText()//limpa texto da barra
    {
        barText.text = "";
    }

    public void PlayScene(StoryScene scene)//proxima leiturada telatela
    {
        currentScene = scene;
        sentenceIndex = -1;
        PlayNextSentence();
    }

    public void PlayNextSentence()
    {
        StartCoroutine(TypeText(currentScene.sentences[++sentenceIndex].text));//ira digitar o texto na tela
        personNameText.text = currentScene.sentences[sentenceIndex].speaker.speakerName;//nome do falante
    }

    public bool IsCompleted()
    {
        return state == State.COMPLETED; //quando a tela é completa
    }

    public bool IsLastSentence()
    {
        return sentenceIndex + 1 == currentScene.sentences.Count;//ultima sentenca
    }

    private IEnumerator TypeText(string text)
    {
        barText.text = "";
        state = State.PLAYING;//quando esta escrevendo no texto
        int wordIndex = 0;

        while (state != State.COMPLETED)
        {
            barText.text += text[wordIndex];
            yield return new WaitForSeconds(0.05f);//da um efeito de escritura ao texto
            if (++wordIndex == text.Length)
            {
                state = State.COMPLETED;//final da escrita
                break;
            }
        }
    }
}
