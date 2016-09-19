using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
    public Transform followTarget;
    public float positionOffset = 0.1f;
    public float rotationOffset = 0.1f;

    private Vector3 angles = Vector3.zero;
    // Use this for initialization
    void Start ()
    {
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        if(followTarget)
        {
            if (Vector3.Distance(transform.position, followTarget.transform.position) > 3)
            {
                GameObject target = followTarget.transform.parent.gameObject;

                /*if (target.GetComponent<TestGlideController>().IsFalling == false)
                {
                    transform.rotation = Quaternion.Lerp(transform.rotation, followTarget.transform.rotation, rotationOffset);
                }
                else if(target.GetComponent<TestGlideController>().IsFalling == true)
                {
                    transform.rotation = Quaternion.Lerp(transform.rotation, followTarget.transform.rotation, 0.9f);
                }*/

                transform.rotation = Quaternion.Lerp(transform.rotation, followTarget.transform.rotation, rotationOffset);
                transform.position = Vector3.Lerp(transform.position, followTarget.transform.position, positionOffset);

                //Quaternion q = new Quaternion(angles);

                angles.x = angles.x + 45.0f;
                angles.y = transform.eulerAngles.y;
                angles.z = transform.eulerAngles.z;
                //transform.eulerAngles = angles;

                //transform.rotation = Quaternion.Lerp(transform.rotation, angles, rotationOffset);
            }
        }
    }
}
