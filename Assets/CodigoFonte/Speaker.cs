using UnityEngine;

[CreateAssetMenu(fileName = "NewSpeaker", menuName = "Data/New Speaker")] //cria um pasta que ira armazenar o falante
[System.Serializable]
public class Speaker : ScriptableObject
{
    public string speakerName;//nome do falante
}
