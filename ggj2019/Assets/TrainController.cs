﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // Change the cube color to green.
        if(other.gameObject.tag == "Bill"){
        GameObject bill = other.transform.gameObject;
        	bill.GetComponent<BillController>().reachedDestination = true;
    	}
    	if(other.gameObject.tag == "Player"){
    		
    	}
    }
    private void OnTriggerExit(Collider other)
    {
        // Revert the cube color to white.
    }
}
