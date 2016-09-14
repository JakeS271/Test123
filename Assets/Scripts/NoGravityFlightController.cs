using UnityEngine;
using System.Collections;
using InControl;

public class NoGravityFlightController : MonoBehaviour {
    [Tooltip("Is the speed at which the glider realigns itself.")]
    public float smooth = 1.0f;
    [Tooltip("Is the speed at which the glider rotates.")]
    public float tiltAngle = 45.0f;
    [Tooltip("How fast it can accelerate.")]
    public float acceleration = 30.0f;
    [Tooltip("It's max speed.")]
    public float maxVelocity = 100;
    [Tooltip("How quickly it slows down we aimed upward.")]
    public float upDeccelerate = 65;
    [Tooltip("How fast it accelerates when aimed downward.")]
    public float downAccelerate = 50;
    [Tooltip("The lowest the speed can be.")]
    private float minVelocity = 0;
    //private Vector3 velocity = new Vector3(0,0,30);
    bool lvlcomplete;

    [Tooltip("A list of objects.")]
    public Transform[] yelOrb;
    private Vector3 angles = Vector3.zero;

	// Use this for initialization
	void Start ()
    {

	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        InputDevice device = InputManager.ActiveDevice;

        float horizontal = Input.GetAxis("Horizontal") + device.LeftStick.X;
        float vertical = Input.GetAxis("Vertical") + device.LeftStick.Y;

        angles.z = Mathf.LerpAngle(angles.z, 0, Time.deltaTime * smooth);
        angles.x = Mathf.LerpAngle(angles.x, 10, Time.deltaTime * 0.4f);

        angles.x = Mathf.Clamp(angles.x + vertical * tiltAngle * Time.deltaTime, -60, 90);
        angles.y = angles.y + horizontal * tiltAngle * Time.deltaTime;
        angles.z = Mathf.Clamp(angles.z + horizontal * -tiltAngle * Time.deltaTime, -90, 90);
        transform.eulerAngles = angles;
                 
        transform.position += transform.forward * Time.deltaTime * Accelerate(); //* velocity;      
	}

    float Accelerate()
    {
        if(angles.x > 0)
        {
            // if you are facing down, accelerate quickly
            acceleration += angles.x / downAccelerate;                      
        }
        else if (angles.x < 0)
        {
            // if you are facing up, deccelerate slowly - slower than you speed up going down
            acceleration += angles.x / upDeccelerate;            
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

    void OnTriggerEnter(Collider col)
    {
        foreach (Transform orb in yelOrb)
        {
            if (col.gameObject == orb.gameObject)
            {
                //Debug.Log ("You had a collision");
                orb.gameObject.SetActive(false);
            }
        }
        //check if level is complete
        foreach (Transform orb in yelOrb)
        {
            if (orb.gameObject.activeSelf == true)
            {
                lvlcomplete = false;
                break;
            }
            lvlcomplete = true;
        }
    }
}