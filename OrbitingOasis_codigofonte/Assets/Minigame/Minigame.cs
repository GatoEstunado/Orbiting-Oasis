using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minigame : MonoBehaviour
{
    public Obstaculos obs;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            obs.Dano();
        }
    }
}
