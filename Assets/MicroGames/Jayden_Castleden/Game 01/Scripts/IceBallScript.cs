﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using StirlingMulvey;

namespace JaydenGame01
{
    public class IceBallScript : MonoBehaviour
    {

        public GameObject iceBall;
        public Transform scorp;
        public GameObject person;

        public float speed = 1f;

        public Text fatal;

        public float time = 1f;
        
        public bool move;
        public bool lose;
        public bool win;
        public Renderer scorRend;

        public Material ice;
        // Use this for initialization
        void Start()
        {
            
           
            move = true;
            fatal.enabled = false;
            person.SetActive(false);
        }



        // Update is called once per frame
        void Update()
        {
            lose = GetOverHere.win;
            time += 1 * Time.deltaTime;
            Ice();
            if (move == false)
            {
                transform.position = Vector3.MoveTowards(transform.position, scorp.position, speed * Time.deltaTime);
            }
        }

        void OnTriggerEnter(Collider scorpi)
        {

            if (scorpi.gameObject.CompareTag("Scorpi"))
            {
                person.SetActive(true);
                fatal.enabled = true;
                scorRend = scorpi.gameObject.GetComponent<Renderer>();
                scorRend.material = ice;

            }
        }

        void Ice()
        {
            if (!lose)
            {
                GlobalGameManager.gameWon = false;
                move = false;
            }
        }
    }
}
