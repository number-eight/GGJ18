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
    public ParticleSystem sys1;
    public ParticleSystem sys2;
    public ParticleSystem sysm1;
    public ParticleSystem sysm2;
    public ParticleSystem sysm3;
    public ParticleSystem sysm4;

    public bool gameOver;
    public int numPlayers;
    public Color occlusion;

    // Use this for initialization
    void Start () {
        // only allow the game to be played in portrait orientation
        Screen.autorotateToPortrait = true;
        Screen.autorotateToPortraitUpsideDown = true;
        Screen.autorotateToLandscapeLeft = false;
        Screen.autorotateToLandscapeRight = false;

        // the translucent rectangle that serves as the player's health bar
        occlusion = new Color(1, 1, 1, 0.5f);

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
        sr1[1].color = occlusion;
        SpriteRenderer[] sr2 = player2.GetComponentsInChildren<SpriteRenderer>();
        sr2[1].color = occlusion;

        health1 = sr1[1];
        health2 = sr2[1];

        // Initialize particle systems
        sys1 = GameObject.FindGameObjectWithTag("Particle1").GetComponent<ParticleSystem>();
        sys2 = GameObject.FindGameObjectWithTag("Particle2").GetComponent<ParticleSystem>();
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
        sr1[1].color = occlusion;
        SpriteRenderer[] sr2 = player2.GetComponentsInChildren<SpriteRenderer>();
        sr2[1].color = occlusion;
        SpriteRenderer[] sr3 = player3.GetComponentsInChildren<SpriteRenderer>();
        sr3[1].color = occlusion;


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
        sr1[1].color = occlusion;
        SpriteRenderer[] sr2 = player2.GetComponentsInChildren<SpriteRenderer>();
        sr2[1].color = occlusion;
        SpriteRenderer[] sr3 = player3.GetComponentsInChildren<SpriteRenderer>();
        sr3[1].color = occlusion;
        SpriteRenderer[] sr4 = player4.GetComponentsInChildren<SpriteRenderer>();
        sr4[1].color = occlusion;


        health1 = sr1[1];
        health2 = sr2[1];
        health3 = sr3[1];
        health4 = sr4[1];

        // Initialize particle systems
        sysm1 = GameObject.FindGameObjectWithTag("Particle_m1").GetComponent<ParticleSystem>();
        sysm2 = GameObject.FindGameObjectWithTag("Particle_m2").GetComponent<ParticleSystem>();
        sysm3 = GameObject.FindGameObjectWithTag("Particle_m3").GetComponent<ParticleSystem>();
        sysm4 = GameObject.FindGameObjectWithTag("Particle_m4").GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        // tap events on Android is also interpreted as mouse button down events
        if (Input.GetMouseButtonDown(0) && gameOver == false)
            {
                Vector2 position = Input.mousePosition;
                Debug.Log(position);
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
            sys1.Emit(5);
            Debug.Log("emit from P1");
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
            sys2.Emit(5);
            Debug.Log("emit from P2");
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
            sysm1.Emit(5);
            Debug.Log("emit from P_m1");
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
            sysm2.Emit(5);
            Debug.Log("emit from P_m2");
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
            sysm3.Emit(5);
            Debug.Log("emit from P_m3");
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
            sysm4.Emit(5);
            Debug.Log("emit from P_m4");
        }
    }

    void decrementHealth(SpriteRenderer sr, int value)
    {
        Vector3 before = sr.bounds.size;
        sr.transform.localScale += new Vector3(0,-0.01f,0);
    }
}
