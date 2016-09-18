using UnityEngine;
using System.Collections;
using InControl;

public class GlideController : MonoBehaviour
{
	[Tooltip("Whether to use this objects artificial gravity or not.")]
	public bool useGravity = true;
	[Tooltip("The speed at which the glider realigns itself.")]
	public float smooth = 1.0f;
	[Tooltip("The speed at which the glider rotates.")]
	public float tiltAngle = 45.0f;
	[Tooltip("Angle the glider readjusts to when controls are released.")]
	public float readjustAngle = 10;
	[Tooltip("The speed the glider readjusts when controls are released.")]
	public float readjustRate = 0.4f;
	[Tooltip("How fast the glider can accelerate.")]
	public float acceleration = 30.0f;
	[Tooltip("The glider's max speed.")]
	public float maxVelocity = 100;
	[Tooltip("How quickly the glider slows down when aimed upward.")]
	public float upDeccelerate = 65;
	[Tooltip("How fast the glider accelerates when aimed downward.")]
	public float downAccelerate = 50;
	[Tooltip("The lowest possible flight speed.")]
	private float minVelocity = 0;
	[Tooltip("The yellow orb target - to obtain it's transform values.")]
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
			angles.x = Mathf.LerpAngle(angles.x, readjustAngle, Time.deltaTime * readjustRate);

			angles.x = Mathf.Clamp(angles.x + vertical * tiltAngle * Time.deltaTime, -60, 90);
			angles.y = angles.y + horizontal * tiltAngle * Time.deltaTime;
			angles.z = Mathf.Clamp(angles.z + horizontal * -tiltAngle * Time.deltaTime, -90, 90);
			transform.eulerAngles = angles;

			if (acceleration > minVelocity)
			{
				transform.position += transform.forward * Time.deltaTime * Accelerate(); //* velocity;
			}
			else
			{
				Vector3 gravity = new Vector3(transform.position.x, (transform.position.y + Time.deltaTime * Accelerate()), transform.position.z);
				transform.position = gravity;
			}


			//Debug.Log(transform.forward);
		}
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "Yellow Orb") 
		{			
			Destroy(col.gameObject);
		}
	}

	float Accelerate()
	{
		
//		acceleration += angles.x / TimeFactor();   

		// If glider pointed downward and acceleration greater than 0, start to speed up
		if(angles.x > 0 && acceleration > 0)
		{
			// if you are facing down, accelerate quickly
			acceleration += angles.x / (downAccelerate );  

		}
		// else if glider pointed down but acceleration is in the negatives due to gravity, after upward flight, 
		// convert the negative acceleration (used for gravity pull) into positive downwards acceleration
		else if (angles.x > 0 && acceleration < 0)
		{
			// if you are facing up, deccelerate slowly - slower than you speed up going down
			acceleration *= -1;            
		}
		else if (angles.x < 0)
		{
			// if you are facing up, deccelerate slowly - slower than you speed up going down
			acceleration += angles.x / (upDeccelerate );            
		}



		if (acceleration < minVelocity)
		{
			// if in built gravity is not in use, reset acceleration to 0
			if(useGravity == false)
			{
				acceleration = minVelocity;
			}
		}
		else if (acceleration > maxVelocity)
		{
			acceleration = maxVelocity;
		}
		return acceleration;
	}
}
