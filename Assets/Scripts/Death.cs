using UnityEngine;
using System.Collections;

public class Death : MonoBehaviour {

    public ParticleSystem explosion;
    
	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
	
	}

    void OnTriggerEnter(Collider col)
    {
        explosion.gameObject.transform.position = transform.position; 

        explosion.Play();
        Debug.Log("Collided");

        transform.GetChild(0).parent = null;

        Destroy(gameObject);
    }

}
