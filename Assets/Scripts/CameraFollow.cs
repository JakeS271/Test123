using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
    public Transform followTarget;
    public float positionOffset = 0.1f;
    public float rotationOffset = 0.1f;

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
                //followTarget.parent.gameObject.GetComponent < TestGlideController >
                //if ()
                transform.position = Vector3.Lerp(transform.position, followTarget.transform.position, positionOffset);
                transform.rotation = Quaternion.Lerp(transform.rotation, followTarget.transform.rotation, positionOffset);
            }
        }
    }
}
