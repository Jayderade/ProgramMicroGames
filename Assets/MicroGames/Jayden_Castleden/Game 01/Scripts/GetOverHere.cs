﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetOverHere : MonoBehaviour {

    public GameObject spear;
    public Transform sub;
    public GameObject scorp;
    public Transform lastRope;


    public float time = 1f;
    public float speed = 1f;

    public bool move;
    public bool activetime;

    public MeshRenderer ropeRend;
    

	// Use this for initialization
	void Start () {
        time += 1 * Time.deltaTime;
        move = true;
        activetime = true;
        
    }
	
	// Update is called once per frame
	void Update () {
        Spear();
        time += 1 * Time.deltaTime;
        if (time >= 4)
        {
            activetime = false;
        }
            if (move == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, lastRope.position, speed * Time.deltaTime);
        }

        
    }

    void OnTriggerExit(Collider rope)
    {
        
        if (rope.gameObject.CompareTag("Rope"))
        {
            
            ropeRend = rope.gameObject.GetComponent<MeshRenderer>();
            ropeRend.enabled = true;
            
        }
    }

    void Spear ()
    {
        if (activetime)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                move = false;
            }
        }
    }
}
