using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class P1 : MonoBehaviour {

    public string test = "test";
    public int damage;
    public int maxDamage = 10;
    public bool isAlive = true;

    // Use this for initialization
    void Start () {
        damage = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void UpdateDamage(int increment)
    {
        damage += increment;
        checkIfAlive();
    }

    public void checkIfAlive()
    {
        if (damage == maxDamage)
        {
            isAlive = false;
        }
    }
}
