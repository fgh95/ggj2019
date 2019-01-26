using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillManagerController : MonoBehaviour
{
	public int maxBills = 10;
	public int minBills = 50;

	private GameObject[] bills;
	private GameObject[] billSpawners;
    // Start is called before the first frame update
    void Start()
    {
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
    		

    	}
    	bills = GameObject.FindGameObjectsWithTag("Bill");
 

    }

    // Update is called once per frame
    void Update()
    {
        foreach(GameObject b in bills){
        	if(!b.active){
        		int spawnIndex = Random.Range (0, billSpawners.Length);
        		b.transform.position = billSpawners[spawnIndex].GetComponent<BillSpawnerController>().getSpawnLocation();
        		b.SetActive(true);
    			int targetIndex = Random.Range (0, billSpawners.Length);
    			while(targetIndex == spawnIndex){
    			targetIndex = Random.Range (0, billSpawners.Length);
    		}

    		UnityEngine.AI.NavMeshAgent bAgent = b.gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
    		bAgent.SetDestination(billSpawners[targetIndex].transform.parent.Find("EndZone").transform.position);
        	
        }
    	}
    }
}
