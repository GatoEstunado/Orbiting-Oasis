using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public StoryScene currentScene;
    public BottomBarController bottomBar;
    public BackgroundController backgroundController;
    public ChooseController chooseController;

    private State state = State.IDLE;

    private enum State
    {
        IDLE, ANIMATE, CHOOSE
    }

    void Start()
    {
        if (currentScene is StoryScene)
        {
            StoryScene storyScene = currentScene as StoryScene;
            bottomBar.PlayScene(currentScene); //da play na primera cena
            backgroundController.SetImage(currentScene.background);//muda background
        }
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



    public void PlayScene(GameScene scene)
    {
        StartCoroutine(SwitchScene(scene));
    }
    private IEnumerator SwitchScene(GameScene scene)
    {
        state = State.ANIMATE;
        currentScene = scene;
        bottomBar.Hide();
        yield return new WaitForSeconds(1f);
        if (scene is StoryScene)
        {
            StoryScene storyScene = scene as StoryScene;
            backgroundController.SetImage(storyScene.background);
            yield return new WaitForSeconds(1f);
            bottomBar.ClearText();
            bottomBar.Show();
            yield return new WaitForSeconds(1f);
            bottomBar.PlayScene(storyScene);
            state = State.IDLE;
        }
        else if (scene is ChooseScene)
        {
            state = State.CHOOSE;
            chooseController.SetupChoose(scene as ChooseScene);
        }
    }
}
