using UnityEngine;//
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class DialogueManager : MonoBehaviour
{

    DialogueParser parser; //Passador de dialogos que sera conectado aqui

    public string dialogue, characterName;
    public int lineNum;
    int pose;
    string position;
    string[] options; //dados que serao passados do parser

    public bool playerTalking; //verificara de o player tera uma escolha;
    List<Button> buttons = new List<Button>(); //lista para armazenar os bottoes para escolhas

    public Text dialogueBox;
    public Text nameBox;
    public GameObject choiceBox; //elementos que se tornarao a caixa de texto

    // Use this for initialization 
    void Start()
    {
        dialogue = "";
        characterName = "";
        pose = 0;
        position = "L";
        playerTalking = false; //iniciando as variaveis para evitar errors

        parser = GameObject.Find("DialogueParser").GetComponent<DialogueParser>(); //pegando o script do passador de dialogos
        lineNum = 0;
    }

    // Update is called once per frame 
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && playerTalking == false)
        {
            ShowDialogue();

            lineNum++;
        } //caso o player clique sem ter uma opcao de escolha, o dialogo pula para proxima fala; 

        UpdateUI();
    }

    public void ShowDialogue()
    {
        ResetImages();
        ParseLine();
    }  //chama funcoes para ler o dialogo

    void UpdateUI()
    {
        if (!playerTalking)
        {
            ClearButtons();
        }
        dialogueBox.text = dialogue;
        nameBox.text = characterName;
    } //caso o player nao esteja fazendo uma escolha a UI sera modificada para a caixa de texto;

    void ClearButtons()
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            print("Clearing buttons");
            Button b = buttons[i];
            buttons.Remove(b);
            Destroy(b.gameObject);
        } //destroy os botoes depois do player escolher
    }

    void ParseLine()
    {
        if (parser.GetName(lineNum) != "Player")
        {
            playerTalking = false;
            characterName = parser.GetName(lineNum);
            dialogue = parser.GetContent(lineNum);
            pose = parser.GetPose(lineNum);
            position = parser.GetPosition(lineNum);
            DisplayImages(); //caso o player nao esteja fazendo escolhas o parse ira chamar os dados das linhas construindo o dialogo
        }
        else
        {
            playerTalking = true;
            characterName = "";
            dialogue = "";
            pose = 0;
            position = "";
            options = parser.GetOptions(lineNum);
            CreateButtons();
        }  //caso o player esteja fazendo uma escolha, apara os dados da caixa de texto, tera as escolhas e criara os botoes
    }

    void CreateButtons()
    {
        for (int i = 0; i < options.Length; i++)
        {
            GameObject button = (GameObject)Instantiate(choiceBox); //cria a quantidade de botoes necessaria para atender a quantidade de escolhas; 
            Button b = button.GetComponent<Button>();
            ChoiceButton cb = button.GetComponent<ChoiceButton>(); //pega scripts de botoes da unity
            cb.SetText(options[i].Split(':')[0]);
            cb.option = options[i].Split(':')[1]; //le as opcoes de escolha do player escrevendo-as nos botoess
            cb.box = this;
            b.transform.SetParent(this.transform); //coloca o game object que tem esse script como pai dos botoes na hierarquia

            b.transform.localPosition = new Vector3(0, -25 + (i * 50));
            b.transform.localScale = new Vector3(1, 1, 1);
            buttons.Add(b); //ajusta a posicao e escala dos botoes
        }
    }

    void ResetImages()
    {
        if (characterName != "")
        {
            GameObject character = GameObject.Find(characterName); //deleta imagens que nao estejam sendo utilizadas; 
            SpriteRenderer currSprite = character.GetComponent<SpriteRenderer>(); //Ira pegar os sprites a serem utilizados
            currSprite.sprite = null;
        }
    }

    void DisplayImages()
    {
        if (characterName != "")
        {
            GameObject character = GameObject.Find(characterName); //ve o personagem que esta falando e acha seu sprite
            SetSpritePositions(character);

            SpriteRenderer currSprite = character.GetComponent<SpriteRenderer>();
            currSprite.sprite = character.GetComponent<Character>().characterPoses[pose]; //rederiza o sprite na tela utilizando uma funcao para localiza-lo;
        }
    }


    void SetSpritePositions(GameObject spriteObj)
    {
        if (position == "L")
        {
            spriteObj.transform.position = new Vector3(-6, 0);
        }
        else if (position == "R")
        {
            spriteObj.transform.position = new Vector3(6, 0);
        }
        spriteObj.transform.position = new Vector3(spriteObj.transform.position.x, spriteObj.transform.position.y, 0);
    } //define a posicao do sprite na tela 
}