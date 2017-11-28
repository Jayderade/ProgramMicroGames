using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using StirlingMulvey;

namespace JaydenGame01
{
    public class GetOverHere : MonoBehaviour
    {

        public GameObject spear;
        public Transform sub;
        public GameObject scorp;
        public Transform lastRope;
        public GameObject iceBall;
        public GameObject person;

        public GameObject[] spawn;

        public Text fatal;


        public float time = 1f;
        public float speed = 1f;

        public static bool win;
        public bool move;
        public bool activetime;

        public MeshRenderer ropeRend;


        void Awake()
        {
            win = GlobalGameManager.gameWon = true;
            GlobalGameManager.verb = "Shoot!";
            spawn = GameObject.FindGameObjectsWithTag("Spawner");

            
        }

        // Use this for initialization
        void Start()
        {

            time += 1 * Time.deltaTime;
            move = true;
            activetime = true;
            fatal.enabled = false;
            person.SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {
            Spear();
            time += 1 * Time.deltaTime;
            if (time >= 7f && move)
            {
                activetime = false;
                win = false;
            }
            if (move == false)
            {
                transform.position = Vector3.MoveTowards(transform.position, lastRope.position, speed * Time.deltaTime);
            }


        }

        void OnTriggerEnter(Collider sub)
        {
            if (sub.gameObject.CompareTag("Sub"))
            {
                GlobalGameManager.gameWon = true;
                
                fatal.enabled = true;
                person.SetActive(true);
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

        void Spear()
        {
            if (activetime)
            {
                if (Input.GetButton("Fire1"))
                {
                    
                    iceBall.SetActive(false);
                    move = false;
                }
            }
        }
    }
}