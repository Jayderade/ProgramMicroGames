using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSelect : MonoBehaviour {

    public GameObject farLeftPer;
    public GameObject leftPer;
    public GameObject midPer;
    public GameObject rightPer;
    public GameObject farRightPer;
   

    public int randPer;
    public int randNet;

    // Use this for initialization
    void Start () {

        randPer = Random.Range(0, 4);
        randNet = Random.Range(0, 2);

        

        farLeftPer.SetActive(false);
        leftPer.SetActive(false);
        midPer.SetActive(false);
        rightPer.SetActive(false);
        farRightPer.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        
        ActivatePerson();
	}
    
    public void ActivatePerson()
    {
        if(randPer == 0)
        {
            farRightPer.SetActive(true);
        }
        if (randPer == 1)
        {
            rightPer.SetActive(true);
        }
        if (randPer == 2)
        {
            midPer.SetActive(true);
        }
        if (randPer == 3)
        {
            leftPer.SetActive(true);
        }
        if (randPer == 4)
        {
            farLeftPer.SetActive(true);
        }
    }
}
