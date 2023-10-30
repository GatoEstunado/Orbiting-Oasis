using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public StoryScene currentScene;
    public BottomBarController bottomBar;
    public BackgroundController backgroundController;

    void Start()
    {
        bottomBar.PlayScene(currentScene); //da play na primera cena
        backgroundController.SetImage(currentScene.background);//muda background
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) //input do mouse ou espaco
        {
            if (bottomBar.IsCompleted())
            {
                if (bottomBar.IsLastSentence()) //caso seja a ultima frase
                {
                    currentScene = currentScene.nextScene; //proxima tela
                    bottomBar.PlayScene(currentScene); //le a frase da proxima tela
                    backgroundController.SetImage(currentScene.background);//muda o backgound alterar para maior interação
                }
                else
                {
                    bottomBar.PlayNextSentence(); //proxima frase
                }
            }
        }
    }
}
