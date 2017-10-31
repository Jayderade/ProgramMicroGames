using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBallScript : MonoBehaviour {

    public GameObject iceBall;
    public Transform scorp;

    public float speed = 1f;

    public float time = 1f;

    public bool move;

    public Renderer scorRend;

    public Material ice;
    // Use this for initialization
    void Start () {
        move = true;
        
    }
	
	// Update is called once per frame
	void Update () {
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

            scorRend = scorpi.gameObject.GetComponent<Renderer>();
            scorRend.material = ice;

        }
    }

    void Ice()
    {
        if (time >= 4)
        {
            move = false;
        }
    }
}
