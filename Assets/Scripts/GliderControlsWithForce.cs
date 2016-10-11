using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using InControl;

public class GliderControlsWithForce : MonoBehaviour
{
    [Tooltip("Whether to use this objects artificial gravity or not.")]
    public bool artificialGravity = true;
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
    [Tooltip("How quickly the glider slows when aimed upward. Smaller numbers means faster deceleration.")]
    public float upDeccelerate = 65;
    [Tooltip("How fast the glider accelerates when aimed downward. Smaller numbers means faster acceleration.")]
    public float downAccelerate = 50;

    [Tooltip("The yellow orb target - to obtain it's transform values.")]
    public Transform yelOrb;

    private float minVelocity = 0; // The lowest possible flight speed.
    private Vector3 angles = Vector3.zero;

    private Rigidbody rb;

    private int score = 0;
    public Text scoreText;

    public LayerMask terrainLayer;

    public bool IsFalling
    {
        get { return isFalling; }
    }


    //private Vector3 velocity = new Vector3(0,0,30);
    bool lvlcomplete, isFalling = false;

    // Use this for initialization
    void Start()
    {
        //rb.WakeUp();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        InputDevice device = InputManager.ActiveDevice;

        float horizontal = Input.GetAxis("Horizontal") + device.LeftStick.X;
        float vertical = Input.GetAxis("Vertical") + device.LeftStick.Y;

        angles.z = Mathf.LerpAngle(angles.z, 0, Time.deltaTime * smooth);
        angles.x = Mathf.LerpAngle(angles.x, readjustAngle, Time.deltaTime * readjustRate);

        angles.x = Mathf.Clamp(angles.x + vertical * tiltAngle * Time.deltaTime, -60, 90);
        angles.y = angles.y + horizontal * tiltAngle * Time.deltaTime;
        angles.z = Mathf.Clamp(angles.z + horizontal * -tiltAngle * Time.deltaTime, -90, 90);
        transform.eulerAngles = angles;

        rb.MovePosition(transform.position + (transform.forward * Time.deltaTime * Accelerate()));
    }

    float Accelerate()
    {
        // If glider pointed downward and acceleration greater than 0, start to speed up
        if (angles.x > 0 && acceleration > 0)
        {
            // if you are facing down, accelerate quickly
            acceleration += angles.x / (downAccelerate);
            Debug.Log(acceleration);
        }
        // else if glider pointed down but acceleration is in the negatives due to gravity, after upward flight, 
        // convert the negative acceleration (used for gravity pull) into positive downwards acceleration
        else if (angles.x > 0 && acceleration < 0)
        {
            // if you are facing up, deccelerate slowly - slower than you speed up going down
            acceleration *= -1;
            Debug.Log(acceleration);
        }
        else if (angles.x < 0)
        {
            // if you are facing up, deccelerate slowly - slower than you speed up going down
            acceleration += angles.x / (upDeccelerate);
            Debug.Log(acceleration);
        }

        if (acceleration < minVelocity)
        {
            // if in built gravity is not in use, reset acceleration to 0
            if (artificialGravity == false)
            {
                acceleration = minVelocity;
                Debug.Log(acceleration);
            }
        }
        else if (acceleration > maxVelocity)
        {
            acceleration = maxVelocity;
            Debug.Log(acceleration);
        }
        return acceleration;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Yellow Orb")
        {
            Destroy(col.gameObject);
            AddScore(1);
        }
    }

    void AddScore(int s)
    {
        score += s;
        scoreText.text = "Score: " + score;
    }
}