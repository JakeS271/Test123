using UnityEngine;
using System.Collections;
using InControl;

public class GlideControls : MonoBehaviour {

    public float smooth = 0.75f, tiltAngle = 1.0f;
    private float lift, drag;
    private Vector3 velocity = new Vector3(0,0,30);
    public Vector3 acceleration, force, maxVelocity;

    private Vector3 angles = Vector3.zero;

	// Use this for initialization
	void Start ()
    {

	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        InputDevice device = InputManager.Devices[0];

        float horizontal = Input.GetAxis("Horizontal") + device.LeftStick.X;
        float vertical = Input.GetAxis("Vertical") + device.LeftStick.Y;

        angles.x = Mathf.Clamp(angles.x + vertical * tiltAngle * Time.deltaTime, -60, 90);
        angles.z = Mathf.Clamp(angles.z + horizontal * -tiltAngle * Time.deltaTime, -90, 90);
        angles.y = angles.y + horizontal * tiltAngle * Time.deltaTime;
        transform.eulerAngles = angles;

        /*if (Mathf.Abs(horizontal < 0.1f))
        {

        }*/

        transform.position += transform.forward * Time.deltaTime * 30.0f; //* velocity; 


	}
}
