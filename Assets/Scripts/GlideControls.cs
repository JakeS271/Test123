using UnityEngine;
using System.Collections;

public class GlideControls : MonoBehaviour {

    public float smooth = 0.75f, tiltAngle = 1.0f;
    private float lift, drag;
    private Vector3 velocity;
    public Vector3 acceleration, force;

	// Use this for initialization
	void Start ()
    {
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (transform.eulerAngles.x > 88 && transform.eulerAngles.x < 270)
        {
            transform.Rotate(-tiltAngle * smooth, 0, 0);
        }
        //transform.rotation = new Quaternion(Mathf.Clamp(transform.rotation.x, -88f, 88f),0,0,0);
        if((transform.eulerAngles.x >= 0 && transform.eulerAngles.x <= 88) || (transform.eulerAngles.x >= 270 && transform.eulerAngles.x <= 360))
        {
            if (Input.GetKey("w") || Input.GetKey("up"))
            {
                transform.Rotate(tiltAngle * smooth, 0, 0);
            }
            if (Input.GetKey("s") || Input.GetKey("down"))
            {
                transform.Rotate(-tiltAngle * smooth, 0, 0);
            }
        }

        //transform.Rotate(Time.deltaTime * smooth, 0, 0);

        /*float tiltZ = Input.GetAxis("Horizontal") * tiltAngle;
        float tiltX = Input.GetAxis("Vertical") * tiltAngle;
        Quaternion target = Quaternion.Euler(tiltX, 0, tiltZ);
        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);*/	
	}
}
