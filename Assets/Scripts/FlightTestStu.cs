using UnityEngine;
using System.Collections;

public class FlightTestStu : MonoBehaviour
{

    public float tiltAngle = 10.0F;
    public float smooth = 2.0F;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (transform.eulerAngles.x >= 0 && transform.eulerAngles.x <= 89.9)
        {
            if(Input.GetKey("w") || Input.GetKey("up"))
            {
                transform.Rotate(tiltAngle * smooth, 0, 0);
            }
            
        }
    }
}

