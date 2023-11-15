using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstaculos : MonoBehaviour
{
    public int lives = 5;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Dano()
    {
        lives--;

        GetComponent<SpriteRenderer>().color = Color.red;
        if (lives == 0)
        {
            Destroy(gameObject);
        }
    }
}
