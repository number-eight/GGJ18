using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class World : MonoBehaviour {

    public GameObject player1;
    public GameObject player2;
    public bool gameOver;

    // Use this for initialization
    void Start () {
        gameOver = false;
        // instantiate the first player
        player1 = GameObject.FindWithTag("Player");

        float currentRatio = (float)Screen.width / (float)Screen.height;

        // Declare vectors
        Vector2 transformVector = new Vector2(currentRatio * 10, 5);
        Vector2 translateVector = new Vector2(0, 2.5f);

        // instantiate the second player
        player2 = Instantiate(player1, translateVector, Quaternion.identity);

        //Transform both players
        player1.transform.localScale = transformVector;
        player1.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0);
        player2.transform.localScale = transformVector;
        player2.GetComponent<SpriteRenderer>().color = new Color(0, 0, 1);

    }

    // Update is called once per frame
    void Update()
    {

        //for testing -in-Unity purposes
        if (Input.GetMouseButtonDown(0) && gameOver == false)
            {
                Vector2 position = Input.mousePosition;
                Debug.Log(position);
                ApplyDamage(position);
            }
    }

    void ApplyDamage(Vector2 position)
    {
        if (position.y > 0.5*Screen.height)
        {
            // attack player1
            player1.GetComponent<P1>().UpdateDamage(1);
            Debug.Log("player1: " + player1.GetComponent<P1>().damage);
            if (!player1.GetComponent<P1>().checkIfAlive())
            {
                gameOver = true;
                player2.GetComponent<P1>().winGame();
            }
        }
        else if (position.y == 0.5 * Screen.height)
        {
            // do nothing
        }
        else
        {
            // attack player2
            player2.GetComponent<P1>().UpdateDamage(1);
            Debug.Log("player2: " + player2.GetComponent<P1>().damage);
            if (!player2.GetComponent<P1>().checkIfAlive())
            {
                gameOver = true;
                player1.GetComponent<P1>().winGame();
            }
        }
    }

    //void checkPlayers()
    //{
    //    if(player2.GetComponent<P1>().isAlive == false)
    //    {
    //        Destroy(player2);
    //    }
    //    if (player1.GetComponent<P1>().isAlive == false)
    //    {
    //        Destroy(player1);
    //    }
    //}
}
