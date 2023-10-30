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

public class GameScene : ScriptableObject { }
