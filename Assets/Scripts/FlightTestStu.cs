using UnityEngine;
using System.Collections;
using InControl;

public class FlightTestStu : MonoBehaviour
{

	public float smooth = 1.0f, tiltAngle = 1.0f, acceleration = 30.0f;
	public float maxVelocity, accelTimer = 0, upDeccelerate = 150, downAccelerate = 165;
	private float lift, drag, minVelocity = 0;
	private bool travelDownSet, travelUpSet;
	public Transform yelOrb;
	//private Vector3 velocity = new Vector3(0,0,30);

	private Vector3 angles = Vector3.zero;

    // Use this for initialization
    void Start()    {    }

    // Update is called once per frame
	void FixedUpdate ()
	{
		InputDevice device = InputManager.Devices[0];

		float horizontal = Input.GetAxis("Horizontal") + device.LeftStick.X;
		float vertical = Input.GetAxis("Vertical") + device.LeftStick.Y;



		if (device != null) 
		{
			angles.z = Mathf.LerpAngle(angles.z, 0, Time.deltaTime * smooth);
			angles.x = Mathf.LerpAngle(angles.x, 5, Time.deltaTime * 0.1f);

			angles.x = Mathf.Clamp(angles.x + vertical * tiltAngle * Time.deltaTime, -60, 90);
			angles.y = angles.y + horizontal * tiltAngle * Time.deltaTime;
			angles.z = Mathf.Clamp(angles.z + horizontal * -tiltAngle * Time.deltaTime, -90, 90);
			transform.eulerAngles = angles;

			transform.position += transform.forward * Time.deltaTime * Accelerate(); //* velocity;

			//Debug.Log(transform.forward);
		}
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject == yelOrb.gameObject) 
		{
			//Debug.Log ("You had a collision");
			Destroy(yelOrb.gameObject);
		}
	}

	float Accelerate()
	{
		
//		acceleration += angles.x / TimeFactor();   

		if(angles.x > 0)
		{
			// if you are facing down, accelerate quickly
			acceleration += angles.x / (downAccelerate );  

		}
		else if (angles.x < 0)
		{
			// if you are facing up, deccelerate slowly - slower than you speed up going down
			acceleration += angles.x / (upDeccelerate );            
		}


		if (acceleration < minVelocity)
		{
			acceleration = minVelocity;
		}
		else if (acceleration > maxVelocity)
		{
			acceleration = maxVelocity;
		}
		return acceleration;
	}

	float TimeFactor()
	{		
		accelTimer -= 1;
		return accelTimer;
	}
}
