﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class World : MonoBehaviour {

    public GameObject player1;
    public GameObject player2;
    public SpriteRenderer health1;
    public SpriteRenderer health2;
    public ParticleSystem sys1;
    public ParticleSystem sys2;
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

        //player1Particles = (GameObject)Instantiate(Particles, transformVector, false);

        // hacking in the health bar visualization with overlaid sprites
        SpriteRenderer[] sr1 = player1.GetComponentsInChildren<SpriteRenderer>();
        Color c = sr1[1].color;
        c.a = 0.5f;
        sr1[1].color = c;
        SpriteRenderer[] sr2 = player2.GetComponentsInChildren<SpriteRenderer>();
        sr2[1].color = c;

        health1 = sr1[1];
        health2 = sr2[1];

        // Initialize particle systems
        //ParticleSystem[] sysems = this.GetComponentsInChildren<ParticleSystem>();
        sys1 = GameObject.FindGameObjectWithTag("Particle1").GetComponent<ParticleSystem>();
        Debug.Log("sys1 :" + sys1);
        sys2 = GameObject.FindGameObjectWithTag("Particle2").GetComponent<ParticleSystem>();
        //Debug.Log("systems: " + systems + "with length" + systems.Length);
        //sys1 = systems[0];
        //sys2 = systems[1];
        //Debug.Log("sys1" + sys1);
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
            sys2.Emit(5);
            Debug.Log("emit from P2");
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
            decrementHealth(health2, -1);
            if (!player2.GetComponent<P1>().checkIfAlive())
            {
                gameOver = true;
                player1.GetComponent<P1>().winGame();
            }
            sys1.Emit(5);
            Debug.Log("emit from P1");
        }
    }

    void decrementHealth(SpriteRenderer sr, int value)
    {/*
        Debug.Log("before localscale" + sr.bounds.size);
        Vector3 before = sr.bounds.size;*/
        sr.transform.localScale += new Vector3(0,-0.01f,0);
        /*
        Vector3 after = sr.bounds.size;
        Debug.Log("after localscale" + sr.bounds.size);
        // various adjustments to address the pixels-to-units conversion issue
        var worldToPixels = ((Screen.height / 2.0f) / Camera.main.orthographicSize);
        Debug.Log("worldToPixels: " + worldToPixels);
        float adjustedDiff = (before[1] - after[1]) / worldToPixels;
        Debug.Log("adjustedDiff " + adjustedDiff);
        Vector3 fuckthis = sr.transform.worldToLocalMatrix * new Vector3(0, value * adjustedDiff, 0);
        Debug.Log(fuckthis[1]);
        sr.transform.Translate(fuckthis);*/
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
