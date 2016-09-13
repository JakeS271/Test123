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
        explosion.Play();
        Debug.Log("Collided");
        Destroy(gameObject);
    }

}
