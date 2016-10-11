using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
    public Transform followTarget;
    public float positionOffset = 0.1f;
    public float rotationOffset = 0.1f;
    public float fallingRotation = 90.0f;
    public float fallingPositionOffset = 30.0f;

    private TestGlideController glide;

    // Use this for initialization
    void Start ()
    {
        glide = followTarget.transform.parent.gameObject.GetComponent<TestGlideController>();
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        if(followTarget)
        {
            if (Vector3.Distance(transform.position, followTarget.transform.position) > 3)
            {
                GameObject target = followTarget.transform.parent.gameObject;

                if (glide.acceleration >= 1)
                {
                    transform.rotation = Quaternion.Lerp(transform.rotation, followTarget.transform.rotation, rotationOffset);
                }
                else if(glide.acceleration <= 0)
                {
                    transform.LookAt(target.transform);
                }

                transform.rotation = Quaternion.Lerp(transform.rotation, followTarget.transform.rotation, rotationOffset);
                transform.position = Vector3.Lerp(transform.position, followTarget.transform.position, positionOffset);

            }
        }
    }
}
