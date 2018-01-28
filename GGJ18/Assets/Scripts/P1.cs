using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class P1 : MonoBehaviour {

    public int damage;
    public int maxDamage;
    public bool isAlive;
    public bool gameWon;
    //public GameObject particleSys;

    // Use this for initialization
    void Start () {
        damage = 0;
        maxDamage = 50;
        isAlive = true;
        gameWon = false;
        //Debug.Log("Particle Sys: " + particleSys);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void UpdateDamage(int increment)
    {
        if (isAlive){
            damage += increment;
        }
    }

    public bool checkIfAlive()
    {

        if (damage >= maxDamage && isAlive)
        {
            isAlive = false;
            this.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0);
            createTextBox("Information overload");
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
        Vector2 s = this.GetComponent<SpriteRenderer>().bounds.size;
        if (s.x > s.y)
        {
            myText.rectTransform.sizeDelta = new Vector2((float)(s.x * 50), (float)(s.y * 25));

        }
        else {

            myText.rectTransform.sizeDelta = new Vector2((float)(s.x * 50), (float)(s.y * 75));
        }
        
        myText.resizeTextForBestFit = true;
        myText.font = font;
        myText.text = message;
        myText.alignment = TextAnchor.MiddleCenter;


        Vector2 newPos;

        if (this.transform.position.y == 2.5)
        {

            myText.transform.Rotate(new Vector2(180, 180), Space.World);

            if (this.transform.position.x > 0)
            {

                newPos = new Vector2((float)0.25*Screen.width, (float)0.25 * Screen.height);
            }
            else if (this.transform.position.x < 0)
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
            if (this.transform.position.x > 0)
            {
                newPos = new Vector2((float)0.25 * Screen.width, (float)-0.25 * Screen.height);
            }
            else if (this.transform.position.x < 0)
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
