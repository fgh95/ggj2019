using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TransitionController : MonoBehaviour
{
	private int currentStation = 1;
	private NetworkTraverser networkTraverser;
	private bool onTrain = false;
	private bool offTrain = false;
	private int currentLine = 1;
	private int currentDirection = 1;

	private float aMin = 0.0F;
    private float aMax =  1.0F;

    static float t = 0.0f;
    static float t2 = 0.0f;

    private GameObject player;
    private PlayerController playerCtrl;
    public CanvasGroup transCanvas;
    public TextMeshProUGUI transText;
    // Start is called before the first frame update
    void Start()
    {
        networkTraverser = transform.gameObject.GetComponent<NetworkTraverser>();
    	player = GameObject.Find("Player");
        playerCtrl = player.GetComponent<PlayerController>();
    }

    

    public void getOffTrain(){
    	onTrain = false;
    	offTrain = true;
    	t2 = 0.0f;
    	
    }

    // Update is called once per frame
    void Update()
    {
        if(onTrain){

        	float fade = Mathf.Lerp(aMin, aMax, t);
        	t += 0.5f * Time.deltaTime;


        	//lerp the white screen
        	transCanvas.alpha = fade;

        	//text

        	transText.text = "welcome back";


        	// if (fade >= aMax){
        	// 	onTrain = false;
        	// 	offTrain = false;
        	// 	t = 0.0f;
        	// }
        	
    		//sound changes

    		//start ticking through stations
        	//traverse network every couple of seconds
        }

        if(offTrain){

        	

        	//lerp the white screen
        	transCanvas.alpha = 0.0f;

        	//text

        	transText.text = "welcome back";

        	// if (fade <= aMin){
        	// 	onTrain = false;
        	// 	offTrain = false;
        	// 	t = 0.0f;
        	// }
        	
    		//sound changes

    		//start ticking through stations
        	//traverse network every couple of seconds
        }

        if(!onTrain && !offTrain){
        	transCanvas.alpha = 0.0f;
        }
    }

    public void getOnTrain(int line, int direction)
    {
    	if(line <= 0 || direction == 0){
    		return;
    	}
    	t = 0.0f;
    	onTrain = true;
    	offTrain = false;
    	currentLine = line;
    	currentDirection = direction;
    }
}
