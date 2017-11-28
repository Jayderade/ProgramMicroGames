using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StirlingMulvey;

namespace JaydenGame02
{

    public class Shoot : MonoBehaviour
    {

        public float speed = .1f;
        public bool move;
        public bool win;
        public Transform perExp;
        public GameObject bullet;
        public GameObject explode;
        public GameObject person;
        public GameObject personNon;
        public Light flash;
        public GameObject[] spawn;

        void Awake()
        {
            win = GlobalGameManager.gameWon;
            GlobalGameManager.verb = "Fire!";
            spawn = GameObject.FindGameObjectsWithTag("Spawn");

            foreach (GameObject go in spawn)
            {
                go.GetComponent<Blood>().enabled = false;
            }
        }

        // Use this for initialization
        void Start()
        {
            explode.SetActive(false);
            personNon.SetActive(true);
            flash.enabled = false;
            move = false;
        }

        // Update is called once per frame
        void Update()
        {
            person.SetActive(false);
            flash.enabled = false;
            if (move)
            {
                bullet.transform.position = Vector3.MoveTowards(transform.position, perExp.position, speed * Time.deltaTime);
            }
            if (Input.GetButton("Fire1"))
            {
                foreach (GameObject go in spawn)
                {
                    go.GetComponent<Blood>().enabled = true;
                }
                win = true;
                move = true;
                explode.SetActive(true);
                personNon.SetActive(false);
                flash.enabled = true;
                
            }
            if(win)
            {
                person.SetActive(true);
                win = false;
            }
        }
    }
}