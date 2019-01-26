using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillController : MonoBehaviour
{
	private GameObject player;
	private UnityEngine.AI.NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
         player = GameObject.Find("Player");
         agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
    	Quaternion pForward = Quaternion.LookRotation(player.transform.forward);
        transform.rotation = pForward;
    }
}
