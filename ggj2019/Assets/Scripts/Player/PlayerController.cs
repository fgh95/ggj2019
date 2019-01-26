using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float playerMaxSpeed = 20.0f;
	private Rigidbody playerRigidBody;
	private Vector3 playerDx;
	


    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody>();
        playerDx = new Vector3(0.0f,0.0f,0.0f);
    }

    // Update is called once per frame
    void Update()
    { 
    	playerDx = new Vector3(0.0f,0.0f,0.0f);
    	
    	if (Input.GetKey ("w")) {
            playerDx.z += Time.deltaTime;
        }
        if (Input.GetKey ("s")) {
            playerDx.z -= Time.deltaTime;
        }
        if (Input.GetKey ("d")) {
            playerDx.x += Time.deltaTime;
        }
        if (Input.GetKey ("a")) {
            playerDx.x -= Time.deltaTime;
        }

        //normalise velocity vector
        playerDx = Vector3.Normalize(playerDx);
        playerDx = playerDx*playerMaxSpeed;

        //face the camera
        playerDx = Quaternion.LookRotation(transform.forward) * playerDx;

        //Enforce sticking to the floor (may need to change if we use stairs and shit)
        playerDx = Vector3.ProjectOnPlane(playerDx, Vector3.up);
        playerRigidBody.velocity = new Vector3(playerDx.x,playerRigidBody.velocity.y,playerDx.z);

    }
}
