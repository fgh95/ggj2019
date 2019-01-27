using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BillManagerController : MonoBehaviour
{

	public int minBills = 50;

	private GameObject[] bills;
	private GameObject[] billSpawners;

	public Transform player;
	public PlayerController plyrCtrl;

	private List<GameObject> activeBillSpawners = new List<GameObject>();

	private List<List<Color>> palettes = new List<List<Color>>();
    // Start is called before the first frame update

    public void killAllBills(){
    	foreach(GameObject b in bills){
    		b.GetComponent<BillController>().reachedDestination = true;
    	}
    }

	public void respawnAllBills(){
		
    	for(int i=0; i<minBills; i++){
    		int spawnIndex = Random.Range (0, activeBillSpawners.Count);
    		Transform newBill = activeBillSpawners[spawnIndex].GetComponent<BillSpawnerController>().SpawnBill();
    		
    		int targetIndex = Random.Range (0, activeBillSpawners.Count);
    		while(targetIndex == spawnIndex){
    			targetIndex = Random.Range (0, activeBillSpawners.Count);
    		}
    		BillController bcont = newBill.gameObject.GetComponent<BillController>();
    		newBill.gameObject.SetActive(true);
    		UnityEngine.AI.NavMeshAgent bAgent = newBill.gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
    		bAgent.SetDestination(activeBillSpawners[targetIndex].transform.parent.Find("EndZone").transform.position);
    		
    		
    		bcont.changeColor(palettes[0][Random.Range(0,palettes[0].Count)]);

    	}
    	bills = GameObject.FindGameObjectsWithTag("Bill");
	}

    void Start()
    {
    		//palette construction

 		palettes.Add(new List<Color>());
 		palettes[0].Add(new Color(1.0f,0.38f,0.22f));
 		palettes[0].Add(new Color(1.0f,1.0f,0.615f));
 		palettes[0].Add(new Color(0.745f,0.921f,0.624f));
 		palettes[0].Add(new Color(0.0f,0.639f,0.533f));

 		plyrCtrl = player.gameObject.GetComponent<PlayerController>();

    	bills = GameObject.FindGameObjectsWithTag("Bill");
    	
    	billSpawners = GameObject.FindGameObjectsWithTag("Spawner");

    	foreach(GameObject b in billSpawners){
	    		if(b.GetComponent<BillSpawnerController>().stationModel == plyrCtrl.activeStationModel){
	    			activeBillSpawners.Add(b);
	    		}
    		}
    	 
    	respawnAllBills();
    	

 	

    }

    // Update is called once per frame
    void Update()
    {
    	//regenerate list if active station has changed
    	if(activeBillSpawners[0].GetComponent<BillSpawnerController>().stationModel != plyrCtrl.activeStationModel){
    		
    		activeBillSpawners.Clear();
    		foreach(GameObject b in billSpawners){
	    		if(b.GetComponent<BillSpawnerController>().stationModel == plyrCtrl.activeStationModel){
	    			activeBillSpawners.Add(b);
	    		}
    		}
    		killAllBills();
    		// respawnAllBills();
    	}

        foreach(GameObject b in bills){
        	BillController bcont = b.GetComponent<BillController>();
        	if(bcont.reachedDestination){
        		
        		int spawnIndex = Random.Range (0, activeBillSpawners.Count);
        		b.GetComponent<NavMeshAgent>().enabled = false;
        		b.transform.position = activeBillSpawners[spawnIndex].GetComponent<BillSpawnerController>().getSpawnLocation();
    			b.GetComponent<NavMeshAgent>().enabled = true;
    			int targetIndex = Random.Range (0, activeBillSpawners.Count);
    			while(targetIndex == spawnIndex){
    				targetIndex = Random.Range (0, activeBillSpawners.Count);
    			}
	    		bcont.reachedDestination = false;
	    		bcont.changeColor(palettes[0][Random.Range(0,palettes[0].Count)]);

	    		UnityEngine.AI.NavMeshAgent bAgent = b.gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
	    		bAgent.SetDestination(activeBillSpawners[targetIndex].transform.parent.Find("EndZone").transform.position);
        	
        	}
    	}
    }
}
