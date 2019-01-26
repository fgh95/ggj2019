using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionController : MonoBehaviour
{
	private int currentStation = 1;
	private NetworkTraverser networkTraverser;
	private bool onTrain = false;
	private int currentLine = 1;
	private int direction = 1;
    // Start is called before the first frame update
    void Start()
    {
        networkTraverser = transform.gameObject.GetComponent<NetworkTraverser>();
    }

    public void getOnTrain(){
    	
    }

    public void getOffTrain(){
    	
    }

    // Update is called once per frame
    void Update()
    {
        if(onTrain){
        	//traverse network every couple of seconds
        }
    }
}
