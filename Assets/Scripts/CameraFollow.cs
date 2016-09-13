using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
    //public Transform followObject;
    //public Vector3 offset = new Vector3(0,0,25);
    //private Vector3 position = Vector3.zero, angle = Vector3.zero;

	// Use this for initialization
	void Start ()
    {
        //offset = transform.position - target.position;
    }
	
	// Update is called once per frame
	void LateUpdate ()
    {
        //transform.LookAt(followObject);

//        position.x = followObject.transform.position.x - offset.x;
//        position.y = followObject.transform.position.y - offset.y;
//        position.z = followObject.transform.position.z - offset.z;
//        transform.position = position;

//        angle.x = followObject.gameObject.transform.eulerAngles.x;
//        angle.y = followObject.gameObject.transform.eulerAngles.y;
//        transform.eulerAngles = angle;
    }
}
