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
    public AudioSource bgmSource;
    public AudioSource trainSoundSource;
    public TextMeshProUGUI transText;
    private float transitionTimer = 0.0f;
    private bool transitioned = false;
    private GameObject[] trains;
    // Start is called before the first frame update
    void Start()
    {
        networkTraverser = transform.gameObject.GetComponent<NetworkTraverser>();
    	player = GameObject.Find("Player");
        playerCtrl = player.GetComponent<PlayerController>();
        trains = GameObject.FindGameObjectsWithTag("Train");
    }

    

    public void getOffTrain(){
    	onTrain = false;
    	offTrain = true;
    	t2 = 0.0f;
    	
    }

    void movePlayerToStationModel(int model){
    	List<Vector3> locations = new List<Vector3>();
    	foreach(GameObject s in trains){
    		if(s.transform.Find("BillSpawner").GetComponent<BillSpawnerController>().stationModel == model){
    			locations.Add(s.transform.Find("PlayerSpawner").transform.position);
    		}
    	}
    	if(locations.Count > 0){
    		player.transform.position = locations[Random.Range(0,locations.Count)];
    		playerCtrl.activeStationModel = model;
    	}
    }

    void movePlayerToStation(int station, int direction, int line){

    }

    // Update is called once per frame
    void Update()
    {
        if(onTrain){

        	float fade = Mathf.Lerp(aMin, aMax, t);
        	t += 0.5f * Time.deltaTime;


        	//lerp the white screen
        	transCanvas.alpha = fade;

        	if(transitionTimer < 2.5){
        		transitionTimer += Time.deltaTime;
        	}

        	if(transitionTimer > 2.5 && !transitioned){
        		// playerCtrl.activeLine = currentLine;
        		// playerCtrl.activeDirection = currentDirection;
        		// playerCtrl.activeStation = networkTraverser.getNextStop(playerCtrl.activeLine,playerCtrl.activeDirection,playerCtrl.activeStation,1);
        		//movePlayerToStation(playerCtrl.activeStation,playerCtrl.activeDirection,playerCtrl.activeLine);
        		playerCtrl.activeStationModel = Random.Range(0,3);
        		movePlayerToStationModel(playerCtrl.activeStationModel);
        		transitioned = true;
        		
        	}


        	bgmSource.volume = 1.0f - fade;


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

        	transitionTimer = 0.0f;

        	//lerp the white screen
        	transCanvas.alpha = 0.0f;

			bgmSource.volume = 1.0f;
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

    	transitioned = false;
    	t = 0.0f;
    	onTrain = true;
    	offTrain = false;
    	currentLine = line;
    	currentDirection = direction;
    	trainSoundSource.Play();
    	transitionTimer = 0.0f;
    }
}
