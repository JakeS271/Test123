using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
    public Transform followTarget;
    public float positionOffset = 0.1f;
    public float rotationOffset = 0.1f;
    public float fallingRotation = 90.0f;
    public float fallingPositionOffset = 30.0f;

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

                if (target.GetComponent<TestGlideController>().acceleration >= 1)
                {
                    transform.rotation = Quaternion.Lerp(transform.rotation, followTarget.transform.rotation, rotationOffset);
                }
                else if(target.GetComponent<TestGlideController>().acceleration <= 0)
                {
                    transform.LookAt(target.transform);
                }

                transform.rotation = Quaternion.Lerp(transform.rotation, followTarget.transform.rotation, rotationOffset);
                transform.position = Vector3.Lerp(transform.position, followTarget.transform.position, positionOffset);

            }
        }
    }
}
