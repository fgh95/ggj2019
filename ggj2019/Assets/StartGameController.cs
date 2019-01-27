using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGameController : MonoBehaviour
{
	public Button startButton;
	public AudioSource ping;
    // Start is called before the first frame update
    void Start()
    {
        startButton.onClick.AddListener(startGame);
    }

    void startGame(){
    	ping.Play();
    	SceneManager.LoadScene("SampleScene");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
