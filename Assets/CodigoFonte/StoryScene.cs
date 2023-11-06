using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewStoryScene", menuName ="Data/New Story Scene")] //Cria uma pasta para armazenar as cenas
[System.Serializable]
public class StoryScene : ScriptableObject //scriptableObject diminui a quantidade de data, são salvos como assets não atrelados a objetos
{
    public List<Sentence> sentences; //cria lista do dialogo que irá rodar na tela;
    public Sprite background;
    public StoryScene nextScene;

    [System.Serializable]
    public struct Sentence //estrutura da lista de sentencas
    {
        public string text; //texto
        public Speaker speaker; //pessoa falando
    }
}

public class GameScene : ScriptableObject {

}
/* 
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
 */
