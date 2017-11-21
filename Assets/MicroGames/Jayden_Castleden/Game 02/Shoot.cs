using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

    public float speed = .1f;
    public bool move;
    public Transform perExp;
    public GameObject bullet;
    public GameObject explode;
    public GameObject person;
    public Light flash;
    public GameObject[] spawn;

    void Awake()
    {
        spawn = GameObject.FindGameObjectsWithTag("Spawner");

        foreach (GameObject go in spawn)
        {
            go.GetComponent<BloodSpawn>().enabled = false;
        }
    }

    // Use this for initialization
    void Start () {
        explode.SetActive(false);
        person.SetActive(true);
        flash.enabled = false;
        move = false;
	}
	
	// Update is called once per frame
	void Update () {
        flash.enabled = false;
        if (move)
        {
            bullet.transform.position = Vector3.MoveTowards(transform.position, perExp.position, speed * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            foreach (GameObject go in spawn)
            {
                go.GetComponent<BloodSpawn>().enabled = true;
            }

            move = true;
            explode.SetActive(true);
            person.SetActive(false);
            flash.enabled = true;
            
        }
	}
}
