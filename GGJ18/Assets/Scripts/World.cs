using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class World : MonoBehaviour {

    public GameObject player1;
    public GameObject player2;
    public SpriteRenderer health1;
    public SpriteRenderer health2;
    public bool gameOver;

    // Use this for initialization
    void Start () {
        // only allow the game to be played in portrait orientation
        Screen.autorotateToPortrait = true;
        Screen.autorotateToPortraitUpsideDown = true;
        Screen.autorotateToLandscapeLeft = false;
        Screen.autorotateToLandscapeRight = false;

        gameOver = false;
        // instantiate the first player
        player1 = GameObject.FindWithTag("Player");

        float currentRatio = (float)Screen.width / (float)Screen.height;

        // Declare vectors
        Vector2 transformVector = new Vector2(currentRatio * 10, 5);
        Vector2 translateVector = new Vector2(0, 2.5f);

        // instantiate the second player
        player2 = Instantiate(player1, translateVector, Quaternion.identity);
        player2.transform.Rotate(new Vector2(180, 180), Space.World);

        //Transform both players
        player1.transform.localScale = transformVector;
        player1.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0);
        player2.transform.localScale = transformVector;
        player2.GetComponent<SpriteRenderer>().color = new Color(0, 0, 1);

        SpriteRenderer[] sr1 = player1.GetComponentsInChildren<SpriteRenderer>();
        SpriteRenderer[] sr2 = player2.GetComponentsInChildren<SpriteRenderer>();

        health1 = sr1[1];
        health2 = sr2[1];

        //GameObject health = new GameObject("Health");
        //health.transform.SetParent(player1.transform);
        //SpriteRenderer sr = health.AddComponent<SpriteRenderer>();
        //sr.sprite = player1.GetComponent<SpriteRenderer>().sprite;
        //sr.transform.localScale = transformVector;
        //sr.transform.position = Vector
    }

    // Update is called once per frame
    void Update()
    {
        // tap events on Android is also interpreted as mouse button down events
        if (Input.GetMouseButtonDown(0) && gameOver == false)
            {
                Vector2 position = Input.mousePosition;
                Debug.Log(position);
                ApplyDamage(position);

        }
    }

    // based on the location of the tap, decides which player initiated attack
    void ApplyDamage(Vector2 position)
    {
        if (position.y > 0.5*Screen.height)
        {
            // attack player1
            player1.GetComponent<P1>().UpdateDamage(1);
            Debug.Log("player1: " + player1.GetComponent<P1>().damage);
            decrementHealth(health1, 1);
            if (!player1.GetComponent<P1>().checkIfAlive())
            {
                gameOver = true;
                player2.GetComponent<P1>().winGame();
            }
        }
        else if (position.y == 0.5 * Screen.height)
        {
            // do nothing if attack happened on dividing line between two players
        }
        else
        {
            // attack player2
            player2.GetComponent<P1>().UpdateDamage(1);
            Debug.Log("player2: " + player2.GetComponent<P1>().damage);
            decrementHealth(health2, 1);
            if (!player2.GetComponent<P1>().checkIfAlive())
            {
                gameOver = true;
                player1.GetComponent<P1>().winGame();
            }
        }
    }

    void decrementHealth(SpriteRenderer sr, int value)
    {
        sr.transform.localScale += new Vector3(0,-0.01f,0);
        Debug.Log("whelp");
        //sr.transform.TransformVector();

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
