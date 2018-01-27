using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class World : MonoBehaviour {

    public GameObject player1;
    public GameObject player2;

    // Use this for initialization
    void Start () {
        // instantiate the first player
        player1 = GameObject.FindWithTag("Player");

        float currentRatio = (float)Screen.width / (float)Screen.height;

        Vector2 vec = new Vector2(0, 2.5f);
        // instantiate the second player
        player2 = Instantiate(player1, vec, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetTouch(0).phase == TouchPhase.Ended)
        //{
        //    Vector2 position = Input.GetTouch(0).position;
        //    Debug.Log(position);
        //    ApplyDamage(position);
        //    checkPlayers();
        //}

        //for testing -in-Unity purposes
        if (Input.GetMouseButtonDown(0))
            {
                Vector2 position = Input.mousePosition;
                Debug.Log(position);
                ApplyDamage(position);
                checkPlayers();
            }
    }

    void ApplyDamage(Vector2 position)
    {
        if (position.y > 0.5*Screen.height)
        {
            // attack player1
            player1.GetComponent<P1>().UpdateDamage(1);
            Debug.Log("player1: " + player1.GetComponent<P1>().damage);
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
        }
    }

    void checkPlayers()
    {
        if(player2.GetComponent<P1>().isAlive == false)
        {
            Destroy(player2);
        }
        if (player1.GetComponent<P1>().isAlive == false)
        {
            Destroy(player1);
        }
    }
}
