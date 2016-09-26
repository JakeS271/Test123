using UnityEngine;
using System.Collections;
using InControl;

public class DashScript : MonoBehaviour 
{	
	//[Tooltip("How quickly the glider dashes to the side.")]
	//public float dashValue = 0.7f;
	[Tooltip("How far the glider dashes to the side.")]
	//public float dashDistMultiplier = 2;
	public float dashDistance = 100.0f;
	private float dashRemains = 0;
	private float dashDirection = 0;
	private bool isRollingLeft = false, isRollingRight = false;

	static float t = 0.0f;

	private Vector3 destination, currentPosition;
	// Use this for initialization
	void Start () 	{ }

//	void Update()
//	{
//		Debug.Log("What's up?");
//	}

	void FixedUpdate ()
	{
		InputDevice device = InputManager.Devices[0];

		float horizontal = Input.GetAxis("Horizontal") + device.LeftStick.X;
		float vertical = Input.GetAxis("Vertical") + device.LeftStick.Y;

		if (device != null) 
		{		
//			if(isRollingLeft == true || isRollingRight == true)
//			{
//				Roll();
//			}
			// Currently not dashing and dash cooldown is finished (dashing is available)
			if (dashRemains <= 0)
			{
				dashDirection = 0;
				if((Input.GetKeyDown("q")|| device.LeftBumper.IsPressed))
				{		
					dashDirection = -1;

					//				isRollingLeft = true;
					//				//destination = transform.right * dashDistance;
					//				Vector3 temp = -transform.right * dashDistance + transform.position;
					//				destination = temp;
					//				//destination.x = ((-transform.right * dashDistance) + transform.position).x;
					//				//transform.position += transform.forward * Time.deltaTime * Accelerate();
					//				//destination.x = transform.position.x - dashDistance;
				}
				if((Input.GetKeyDown("e")|| device.RightBumper.IsPressed))
				{	
					dashDirection = 1;
					//				isRollingRight = true;
					//				destination.x = transform.position.x + dashDistance;
				}

				if (dashDirection != 0)
				{
					// Duration of the dash
					dashRemains = 1;
				}
			}
			else
			{
				float lerpSpeed = 1 - (1-dashRemains);
				transform.position += (transform.right * dashDirection * dashDistance * Time.fixedDeltaTime * (lerpSpeed * lerpSpeed));
				dashRemains -= Time.fixedDeltaTime;
			}
		}
	}
	
//	void Roll()
//	{
//		if(isRollingLeft == true && currentPosition != destination)
//		{
//			currentPosition = transform.position;
//			currentPosition.x = Mathf.Lerp(currentPosition.x, destination.x, t);
//			t += dashValue * Time.deltaTime;           
//            transform.position = currentPosition;
//		}
//		else if(isRollingRight == true && currentPosition != destination)
//		{
//			currentPosition = transform.position;
//			currentPosition.x = Mathf.Lerp(currentPosition.x, destination.x, t);
//			t += dashValue * Time.deltaTime;           
//			transform.position = currentPosition;
//		}
//
//		if (currentPosition.x == destination.x)
//		{
//			//Debug.Log("WHATUP");
//			isRollingRight = false;
//			isRollingLeft = false;
//			t = 0.0f;
//		}
//	}

}
