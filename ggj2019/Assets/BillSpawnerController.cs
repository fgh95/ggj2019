using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillSpawnerController : MonoBehaviour
{
	public float spread = 1.0f;
	public Transform billPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Transform SpawnBill()
    {
    	return Instantiate(billPrefab, getSpawnLocation(), Quaternion.identity);
    }

    public Vector3 getSpawnLocation()
    {
    	return transform.position + new Vector3(Random.Range(-spread, spread), 0, Random.Range(-spread, spread));
    }


}
