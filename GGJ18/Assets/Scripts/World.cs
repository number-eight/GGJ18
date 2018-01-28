using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class World : MonoBehaviour {

    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    public GameObject player4;
    public SpriteRenderer health1;
    public SpriteRenderer health2;
    public SpriteRenderer health3;
    public SpriteRenderer health4;
    public bool gameOver;
    public int numPlayers;

    // Use this for initialization
    void Start () {
        // only allow the game to be played in portrait orientation
        Screen.autorotateToPortrait = true;
        Screen.autorotateToPortraitUpsideDown = true;
        Screen.autorotateToLandscapeLeft = false;
        Screen.autorotateToLandscapeRight = false;

        gameOver = false;
        if (this.tag == "4P")
        {
            numPlayers = 4;
            start4P();
        }
        else if (this.tag == "3P"){
            numPlayers = 3;
            start3P();
        }
        else
        {
            numPlayers = 2;
            start2P();
        }

    }

    void start2P()
    {
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

        // hacking in the health bar visualization with overlaid sprites
        SpriteRenderer[] sr1 = player1.GetComponentsInChildren<SpriteRenderer>();
        Color c = sr1[1].color;
        c.a = 0.5f;
        sr1[1].color = c;
        SpriteRenderer[] sr2 = player2.GetComponentsInChildren<SpriteRenderer>();
        sr2[1].color = c;

        health1 = sr1[1];
        health2 = sr2[1];
    }

    void start3P()
    {
        // instantiate the first player
        player1 = GameObject.FindWithTag("Player");

        float currentRatio = (float)Screen.width / (float)Screen.height;

        // Declare vectors

        Vector2 transformVector4P = new Vector2(currentRatio * 5, 5);
        Vector2 translateVectorTopRight = new Vector2(currentRatio * 2.5f, 2.5f);
        Vector2 translateVectorTopLeft = new Vector2(currentRatio * -2.5f, 2.5f);

        // instantiate the second player
        player2 = Instantiate(player1, translateVectorTopLeft, Quaternion.identity);
        player2.transform.Rotate(new Vector2(180, 180), Space.World);

        //instantiate the third player
        player3 = Instantiate(player1, translateVectorTopRight, Quaternion.identity);
        player3.transform.Rotate(new Vector2(180, 180), Space.World);

        //Transform both players
        player1.transform.localScale = transformVector4P;
        player1.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0);
        player2.transform.localScale = transformVector4P;
        player2.GetComponent<SpriteRenderer>().color = new Color(0, 0, 1);
        player3.transform.localScale = transformVector4P;
        player3.GetComponent<SpriteRenderer>().color = new Color(0, 1, 0);

        // hacking in the health bar visualization with overlaid sprites
        SpriteRenderer[] sr1 = player1.GetComponentsInChildren<SpriteRenderer>();
        Color c = sr1[1].color;
        c.a = 0.5f;
        sr1[1].color = c;
        SpriteRenderer[] sr2 = player2.GetComponentsInChildren<SpriteRenderer>();
        sr2[1].color = c;
        SpriteRenderer[] sr3 = player3.GetComponentsInChildren<SpriteRenderer>();
        sr3[1].color = c;


        health1 = sr1[1];
        health2 = sr2[1];
        health3 = sr3[1];
    }

    void start4P()
    {
        // instantiate the first player
        player1 = GameObject.FindWithTag("Player");

        float currentRatio = (float)Screen.width / (float)Screen.height;

        // Declare vectors

        Vector2 transformVector4P = new Vector2(currentRatio * 5, 5);
        Vector2 translateVectorTopRight = new Vector2(currentRatio * 2.5f, 2.5f);
        Vector2 translateVectorTopLeft = new Vector2(currentRatio * -2.5f, 2.5f);
        Vector2 translateVectorBottomRight = new Vector2(currentRatio * 2.5f, -2.5f);
        Vector2 translateVectorBottomLeft = new Vector2(currentRatio * -2.5f, 0);

        // instantiate the second player
        player2 = Instantiate(player1, translateVectorTopLeft, Quaternion.identity);
        player2.transform.Rotate(new Vector2(180, 180), Space.World);

        //instantiate the third player
        player3 = Instantiate(player1, translateVectorTopRight, Quaternion.identity);
        player3.transform.Rotate(new Vector2(180, 180), Space.World);

        //instantiate the fourth player
        player4 = Instantiate(player1, translateVectorBottomRight, Quaternion.identity);

        //Transform both players
        player1.transform.localScale = transformVector4P;
        player1.transform.Translate(translateVectorBottomLeft);
        player1.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0);
        player2.transform.localScale = transformVector4P;
        player2.GetComponent<SpriteRenderer>().color = new Color(0, 0, 1);
        player3.transform.localScale = transformVector4P;
        player3.GetComponent<SpriteRenderer>().color = new Color(0, 1, 0);
        player4.transform.localScale = transformVector4P;
        player4.GetComponent<SpriteRenderer>().color = new Color(0, 1, 1);

        // hacking in the health bar visualization with overlaid sprites
        SpriteRenderer[] sr1 = player1.GetComponentsInChildren<SpriteRenderer>();
        Color c = sr1[1].color;
        c.a = 0.5f;
        sr1[1].color = c;
        SpriteRenderer[] sr2 = player2.GetComponentsInChildren<SpriteRenderer>();
        sr2[1].color = c;
        SpriteRenderer[] sr3 = player3.GetComponentsInChildren<SpriteRenderer>();
        sr3[1].color = c;
        SpriteRenderer[] sr4 = player4.GetComponentsInChildren<SpriteRenderer>();
        sr4[1].color = c;


        health1 = sr1[1];
        health2 = sr2[1];
        health3 = sr3[1];
        health4 = sr4[1];
    }

    // Update is called once per frame
    void Update()
    {
        // tap events on Android is also interpreted as mouse button down events
        if (Input.GetMouseButtonDown(0) && gameOver == false)
            {
                Vector2 position = Input.mousePosition;
                //Debug.Log(position);
            switch (numPlayers)
            {
                case 2:
                    ApplyDamage2P(position);
                    break;
                case 3:
                    break;
                case 4:
                    ApplyDamage4P(position);
                    break;
            }
               

        }
    }

    // based on the location of the tap, decides which player initiated attack
    void ApplyDamage2P(Vector2 position)
    {
        if (position.y < 0.5 * Screen.height && player1.GetComponent<P1>().isAlive)
        {
            // Player 1 attacking
            player2.GetComponent<P1>().UpdateDamage(1);
            //Debug.Log("player2: " + player2.GetComponent<P1>().damage);
            decrementHealth(health2, -1);
            if (!player2.GetComponent<P1>().checkIfAlive())
            {
                gameOver = true;
                player1.GetComponent<P1>().winGame();
            }
        }

        else if (position.y > 0.5 * Screen.height && player2.GetComponent<P1>().isAlive)
        {
            // Player 2 attacking
            player1.GetComponent<P1>().UpdateDamage(1);
            //Debug.Log("player1: " + player1.GetComponent<P1>().damage);
            decrementHealth(health1, 1);
            if (!player1.GetComponent<P1>().checkIfAlive())
            {
                gameOver = true;
                player2.GetComponent<P1>().winGame();
            }
        }
    }

    // based on the location of the tap, decides which player initiated attack
    void ApplyDamage4P(Vector2 position)
    {
        if (position.y < 0.5 * Screen.height && position.x < 0.5 * Screen.width && player1.GetComponent<P1>().isAlive)
        {
            // Player 1 attacking
            player2.GetComponent<P1>().UpdateDamage(1);
            decrementHealth(health2, -1);
            player3.GetComponent<P1>().UpdateDamage(1);
            decrementHealth(health3, -1);
            player4.GetComponent<P1>().UpdateDamage(1);
            decrementHealth(health4, -1);
            //Debug.Log("player2: " + player2.GetComponent<P1>().damage);

            if (!player2.GetComponent<P1>().checkIfAlive() && !player3.GetComponent<P1>().checkIfAlive() && !player4.GetComponent<P1>().checkIfAlive())
            {
                gameOver = true;
                player1.GetComponent<P1>().winGame();
            }
        }

        else if (position.y > 0.5*Screen.height && position.x < 0.5*Screen.width && player2.GetComponent<P1>().isAlive)
        {
            // Player 2 attacking
            player1.GetComponent<P1>().UpdateDamage(1);
            decrementHealth(health1, -1);
            player3.GetComponent<P1>().UpdateDamage(1);
            decrementHealth(health3, -1);
            player4.GetComponent<P1>().UpdateDamage(1);
            decrementHealth(health4, -1);
            //Debug.Log("player1: " + player1.GetComponent<P1>().damage);
            if (!player1.GetComponent<P1>().checkIfAlive() && !player3.GetComponent<P1>().checkIfAlive() && !player4.GetComponent<P1>().checkIfAlive())
            {
                gameOver = true;
                player2.GetComponent<P1>().winGame();
            }
        }
        else if (position.y > 0.5 * Screen.height && position.x > 0.5 * Screen.width && player3.GetComponent<P1>().isAlive)
        {
            // Player 3 attacking
            player1.GetComponent<P1>().UpdateDamage(1);
            decrementHealth(health1, -1);
            player2.GetComponent<P1>().UpdateDamage(1);
            decrementHealth(health2, -1);
            player4.GetComponent<P1>().UpdateDamage(1);
            decrementHealth(health4, -1);
            if (!player1.GetComponent<P1>().checkIfAlive() && !player2.GetComponent<P1>().checkIfAlive() && !player4.GetComponent<P1>().checkIfAlive())
            {
                gameOver = true;
                player3.GetComponent<P1>().winGame();
            }

        }
        else if (position.y < 0.5 * Screen.height && position.x > 0.5 * Screen.width && player4.GetComponent<P1>().isAlive)
        {
            // Player 4 attacking
            player1.GetComponent<P1>().UpdateDamage(1);
            decrementHealth(health1, -1);
            player2.GetComponent<P1>().UpdateDamage(1);
            decrementHealth(health2, -1);
            player3.GetComponent<P1>().UpdateDamage(1);
            decrementHealth(health3, -1);
            if (!player1.GetComponent<P1>().checkIfAlive() && !player2.GetComponent<P1>().checkIfAlive() && !player3.GetComponent<P1>().checkIfAlive())
            {
                gameOver = true;
                player4.GetComponent<P1>().winGame();
            }
        }

    }

    void decrementHealth(SpriteRenderer sr, int value)
    {
        //Debug.Log("before localscale" + sr.bounds.size);
        Vector3 before = sr.bounds.size;
        sr.transform.localScale += new Vector3(0,-0.01f,0);
        Vector3 after = sr.bounds.size;
        //Debug.Log("after localscale" + sr.bounds.size);
        // currently translating at the wrong distance
        // float pixelsLost = (float)0.01* Screen.height / 2;
        var diff = before[1] - after[1] / 2;
        //Vector3 fuckthis = sr.transform.worldToLocalMatrix * new Vector3(0, -diff, 0);
        var worldToPixels = ((Screen.height / 2.0f) / Camera.main.orthographicSize);
        float adjustedDiff = (before[1] - after[1] / 2) / worldToPixels;
        //Debug.Log("adjustedDiff " + adjustedDiff);
        Vector3 fuckthis = sr.transform.worldToLocalMatrix * new Vector3(0, value * adjustedDiff, 0);
        //Debug.Log(fuckthis[1]);
        sr.transform.Translate(fuckthis);
        //sr.transform.TransformVector();
    }

}
