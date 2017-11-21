using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Net : MonoBehaviour
{

    public float movementSpeed = 1f;
    [Header("Explode")]
    public GameObject farLeftEx;
    public GameObject leftEx;
    public GameObject midEx;
    public GameObject rightEx;
    public GameObject farRightEx;
    [Header("No Explode")]
    public GameObject farLeftNoEx;
    public GameObject leftNoEx;
    public GameObject midNoEx;
    public GameObject rightNoEx;
    public GameObject farRightNoEx;
    [Header("Spawner")]
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
    void Start()
    {
        

        farLeftEx.SetActive(false);
        leftEx.SetActive(false);
        midEx.SetActive(false);
        rightEx.SetActive(false);
        farRightEx.SetActive(false);

        farLeftNoEx.SetActive(true);
        leftNoEx.SetActive(true);
        midNoEx.SetActive(true);
        rightNoEx.SetActive(true);
        farRightNoEx.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        // Get Horizontal input
        float inputH = Input.GetAxis("Horizontal");
        float inputV = Input.GetAxis("Vertical");
        // Direction X Input(sign) X Speed X DeltaTime
        transform.position += transform.right * inputH * movementSpeed * Time.deltaTime;
       
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Person"))
        {
            foreach (GameObject go in spawn)
            {
                go.GetComponent<BloodSpawn>().enabled = true;
            }

            farLeftEx.SetActive(true);
            leftEx.SetActive(true);
            midEx.SetActive(true);
            rightEx.SetActive(true);
            farRightEx.SetActive(true);

            farLeftNoEx.SetActive(false);
            leftNoEx.SetActive(false);
            midNoEx.SetActive(false);
            rightNoEx.SetActive(false);
            farRightNoEx.SetActive(false);
        }
    }

}
