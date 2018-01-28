using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour {

    ParticleSystem sys1;
    int test = 5;
    ParticleSystem sys2;

	// Use this for initialization
	void Start () {/*
        ParticleSystem[] systems = GetComponents<ParticleSystem>();
        sys1 = systems[0];
        sys2 = systems[1];
        Debug.Log("systems: " + systems + "with length" + systems.Length);
        Debug.Log("sys1" + sys1);
        //sys.emissionRate = 0;*/
	}
	
	// Update is called once per frame
	void Update () {/*
		if (Input.GetMouseButtonDown(0))
        {
            Vector2 position = Input.mousePosition;
            Debug.Log(position);
            EmitParticles(position);
        }*/
	}
    /*
    void EmitParticles(Vector2 position)
    {
        // attack P1 --> emit from P2
        if (position.y > 0.5 * Screen.height)
        {
            sys2.Emit(5);
            Debug.Log("emit from P2");
        }
        else if (position.y == 0.5 * Screen.height)
        {
            // do nothing if attack happened on dividing line between two players
        }
        else
        {
            // attack P2 --> emit from P1
            sys1.Emit(5);
            Debug.Log("emit from P2");
        }
    }*/
}
