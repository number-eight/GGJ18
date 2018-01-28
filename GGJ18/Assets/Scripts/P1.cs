using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class P1 : MonoBehaviour {

    public int damage;
    public int maxDamage = 100;
    public bool isAlive = true;
    public bool gameWon = false;
    //public GameObject particleSys;

    // Use this for initialization
    void Start () {
        damage = 0;
        //Debug.Log("Particle Sys: " + particleSys);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void UpdateDamage(int increment)
    {
        if (this.isAlive){
            damage += increment;
        }
    }

    public bool checkIfAlive()
    {
        if (damage >= maxDamage)
        {
            isAlive = false;
            this.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0);
            createTextBox("You have lost :(");
        }
        return isAlive;
    }

    public void winGame()
    {
        gameWon = true;

        Color c = this.GetComponent<SpriteRenderer>().color;
        c.a = .5f;
        this.GetComponent<SpriteRenderer>().color = c;
        createTextBox("You won yay!");
        
    }

    public void createTextBox(string message)
    {
        Canvas t = this.GetComponentInChildren<Canvas>();
        GameObject newText = new GameObject("GGText");
        newText.transform.SetParent(t.transform);

        Text myText = newText.AddComponent<Text>();
        Font font = Resources.GetBuiltinResource<Font>("Arial.ttf");
        myText.font = font;
        myText.text = message;
        myText.resizeTextForBestFit = true;
        myText.rectTransform.sizeDelta = new Vector2(100, 50);
        Vector2 newPos;
        Debug.Log(this.transform.position.x);
        Debug.Log(this.transform.position.y);

        if (this.transform.position.y == 2.5)
        {

            myText.transform.Rotate(new Vector2(180, 180), Space.World);

            if (this.transform.position.x == 4)
            {

                newPos = new Vector2((float)0.25*Screen.width, (float)0.25 * Screen.height);
            }
            else if (this.transform.position.x == -4)
            {
                newPos = new Vector2((float)-0.25 * Screen.width, (float)0.25 * Screen.height);
            }
            else
            {
                newPos = new Vector2(0, (float)0.25 * Screen.height);
            }
        }
        else
        {
            if (this.transform.position.x == 4)
            {
                newPos = new Vector2((float)0.25 * Screen.width, (float)-0.25 * Screen.height);
            }
            else if (this.transform.position.x == -4)
            {
                newPos = new Vector2((float)-0.25 * Screen.width, (float)-0.25 * Screen.height);
            }
            else
            {
                newPos = new Vector2(0, (float)-0.25 * Screen.height);
            }
        }
        myText.rectTransform.localPosition = newPos;
    }
}
