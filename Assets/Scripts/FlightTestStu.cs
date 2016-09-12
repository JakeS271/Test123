using UnityEngine;
using System.Collections;
using InControl;

public class FlightTestStu : MonoBehaviour
{

    public float smooth = 0.75f, tiltAngle = 1.0f, leftBoarder = 10.0f, rightBoarder = -10.0f;
    private float lift, drag;
    //private Vector3 velocity = new Vector3(0,0,30);
	bool moveLeft = false;
	bool moveRight = false;
    public Vector3 acceleration, force, maxVelocity;

    private Vector3 angles = Vector3.zero;

    // Use this for initialization
    void Start()    {    }

    // Update is called once per frame
    void FixedUpdate()
    {
        InputDevice device = InputManager.Devices[0];

        float horizontal = Input.GetAxis("Horizontal") + device.LeftStick.X;
        float vertical = Input.GetAxis("Vertical") + device.LeftStick.Y;

        if (device != null)
        {			
//			if(Input.GetKeyDown("left") || Input.GetKeyDown("a"))
//			{
//				moveLeft = true;
//			}
//			if(Input.GetKeyUp("left") || Input.GetKeyUp("a"))
//			{
//				moveLeft = false;
//			}
//			if(Input.GetKeyDown("right") || Input.GetKeyDown("d"))
//			{
//				moveRight = true;
//			}	
//			if(Input.GetKeyUp("right") || Input.GetKeyUp("d"))
//			{
//				moveRight = false;
//			}	

			// mathf.Clamp is to keep the numbers between the range, -90,90
			// horizontal is working out if the player is pressing left or right; if its 0, no movement happens
			// sets the z angle to itself + the horizontal ( direction ) * the tilt angle to alter how fast it rotates, * deltaTime for smoothing, and the range -90,90
            angles.z = Mathf.Clamp(angles.z + horizontal * -tiltAngle * Time.deltaTime, -90, 90); 
			// makes the player always try to rotate back to 0
			// the more the player moves away from 0, it keeps trying to rotate back, but the players controls override the difference
			angles.z = Mathf.LerpAngle (angles.z, 0, Time.deltaTime * 2.0f);

            angles.y = angles.y + horizontal * tiltAngle * Time.deltaTime;
            angles.x = Mathf.Clamp(angles.x + vertical * tiltAngle * Time.deltaTime, -60, 90); 
            transform.eulerAngles = angles;           

            transform.position += transform.forward * Time.deltaTime * 30.0f;

//			if (transform.rotation.z < 0 && moveLeft == false)
//			{
//				
//				//angles.z = 0;
//				//Vector3 q = new Vector3(transform.rotation.x, transform.rotation.y, 0);
//				//transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, q, Time.deltaTime);			
//			}
//			else if (transform.rotation.z > 0 && moveRight == false)
//			{
//				//angles.z = 0;
//				//Vector3 q = new Vector3(transform.rotation.x, transform.rotation.y, 0);
//				//transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, q, -Time.deltaTime);	
//			}

            //if (horizontal != 0)
            //{
            //    angles.z = Mathf.Clamp(angles.z + horizontal * -tiltAngle * Time.deltaTime, -90, 90);
            //    angles.y = angles.y + horizontal * tiltAngle * Time.deltaTime;
            //    transform.eulerAngles = angles;
            //}
            //if (vertical != 0)
            //{
            //    angles.x = Mathf.Clamp(angles.x + vertical * tiltAngle * Time.deltaTime, -60, 90);
            //    transform.eulerAngles = angles;
            //}
            //else
            //{
            //    angles.z = 0;
            //    Vector3 q = new Vector3(transform.rotation.x, transform.rotation.y, 0);
            //    transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, q, Time.deltaTime);
            //}


            //* velocity;
            //if(angles.y <= leftBoarder && angles.y >= rightBoarder)
            //{
            //    if (horizontal == 0)
            //    {
            //        angles.z = angles.z - tiltAngle * Time.deltaTime;
            //        print("Is Between");
            //    }
            //}



        }

    }
}
