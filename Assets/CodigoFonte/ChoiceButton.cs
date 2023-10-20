using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChoiceButton : MonoBehaviour
{

    public string option;
    public Dialoguemanager box;

    // Use this for initialization 
    void Start()
    {

    }

    // Update is called once per frame 
    void Update()
    {

    }

    public void SetText(string newText)
    {
        this.GetComponentInChildren<Text>().text = newText; //altera o texto do botão 
    }

    public void SetOption(string newOption)
    {
        this.option = newOption; //altera a opção
    }

    public void ParseOption()
    {
        string command = option.Split(',')[0];
        string commandModifier = option.Split(',')[1];
        box.playerTalking = false;//player para de falar
        if (command == "line")
        {
            box.lineNum = int.Parse(commandModifier);
            box.ShowDialogue();
        }
        else if (command == "scene")
        {
            Application.LoadLevel("Scene" + commandModifier);
        }
        //checa as mudanças causadas pela escolha
    }
}