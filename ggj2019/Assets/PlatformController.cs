using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
	public int line;
	public int direction;

	private TransitionController transitionCtrl;
    // Start is called before the first frame update
    void Start()
    {
        GameObject transitions = GameObject.Find("TransitionManager");
        transitionCtrl = transitions.GetComponent<TransitionController>();
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    private void OnTriggerEnter(Collider other){
    	if(other.gameObject.tag == "Player"){
    		transitionCtrl.getOnTrain(line,direction);
    	}

    }

     private void OnTriggerExit(Collider other){
    	if(other.gameObject.tag == "Player"){
    		transitionCtrl.getOffTrain();
    	}

    }
}
