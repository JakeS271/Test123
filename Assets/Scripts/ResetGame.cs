using UnityEngine;
using System.Collections;
using InControl;
using UnityEngine.SceneManagement;

public class ResetGame : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        InputDevice device = InputManager.ActiveDevice;

        if (Input.GetKeyDown(KeyCode.Escape) || device.Action2)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
	}
}
