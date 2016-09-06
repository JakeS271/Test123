using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
    private Vector3 angles = Vector3.zero;

	// Use this for initialization
	void Start ()
    {
        //offset = transform.position - target.position;
    }
	
	// Update is called once per frame
	void LateUpdate ()
    {
       if(transform.eulerAngles.z != 0)
        {
            angles.x = transform.eulerAngles.x;
            angles.y = transform.eulerAngles.y;
            angles.z = 0;
            transform.eulerAngles = angles;
        }
    }
}
