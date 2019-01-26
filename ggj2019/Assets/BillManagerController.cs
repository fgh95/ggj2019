using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillManagerController : MonoBehaviour
{
	public int maxBills = 10;
	public int minBills = 50;

	private GameObject[] bills;
	private GameObject[] billSpawners;

	private List<List<Color>> palettes = new List<List<Color>>();
    // Start is called before the first frame update
    void Start()
    {
    		//palette construction

 		palettes.Add(new List<Color>());
 		palettes[0].Add(new Color(1.0f,0.38f,0.22f));
 		palettes[0].Add(new Color(1.0f,1.0f,0.615f));
 		palettes[0].Add(new Color(0.745f,0.921f,0.624f));
 		palettes[0].Add(new Color(0.0f,0.639f,0.533f));

    	bills = GameObject.FindGameObjectsWithTag("Bill");
    	
    	billSpawners = GameObject.FindGameObjectsWithTag("Spawner");
    	for(int i=bills.Length; i<minBills; i++){
    		int spawnIndex = Random.Range (0, billSpawners.Length);
    		Transform newBill = billSpawners[spawnIndex].GetComponent<BillSpawnerController>().SpawnBill();
    		int targetIndex = Random.Range (0, billSpawners.Length);
    		while(targetIndex == spawnIndex){
    			targetIndex = Random.Range (0, billSpawners.Length);
    		}
    		newBill.gameObject.SetActive(true);
    		UnityEngine.AI.NavMeshAgent bAgent = newBill.gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
    		bAgent.SetDestination(billSpawners[targetIndex].transform.parent.Find("EndZone").transform.position);
    		BillController bcont = newBill.gameObject.GetComponent<BillController>();
    		bcont.changeColor(palettes[0][Random.Range(0,palettes[0].Count)]);

    	}
    	bills = GameObject.FindGameObjectsWithTag("Bill");

 	

    }

    // Update is called once per frame
    void Update()
    {
        foreach(GameObject b in bills){
        	BillController bcont = b.GetComponent<BillController>();
        	if(bcont.reachedDestination){
        		int spawnIndex = Random.Range (0, billSpawners.Length);
        		b.transform.position = billSpawners[spawnIndex].GetComponent<BillSpawnerController>().getSpawnLocation();
    			int targetIndex = Random.Range (0, billSpawners.Length);
    			while(targetIndex == spawnIndex){
    			targetIndex = Random.Range (0, billSpawners.Length);
    			bcont.reachedDestination = false;
    		}
    		bcont.changeColor(palettes[0][Random.Range(0,palettes[0].Count)]);

    		UnityEngine.AI.NavMeshAgent bAgent = b.gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
    		bAgent.SetDestination(billSpawners[targetIndex].transform.parent.Find("EndZone").transform.position);
        	
        }
    	}
    }
}
