using UnityEngine;
using System.Collections;

public class TestCamera : MonoBehaviour
{
    public Transform followTarget;
    public float positionOffset = 0.1f;
    public float rotationOffset = 0.1f;
    public float fallingRotation = 90.0f;
    public float fallingPositionOffset = 30.0f;
    public Component flightScript;

    private GliderControlsWithForce glider;

    // Use this for initialization
    void Start()
    {
        glider = followTarget.transform.parent.gameObject.GetComponent<GliderControlsWithForce>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (followTarget)
        {
            if (Vector3.Distance(transform.position, followTarget.transform.position) > 3)
            {
                GameObject target = followTarget.transform.parent.gameObject;

                if (glider.acceleration >= 1)
                {
                    transform.rotation = Quaternion.Lerp(transform.rotation, followTarget.transform.rotation, rotationOffset);
                }
                else if (glider.acceleration <= 0)
                {
                    transform.LookAt(target.transform);
                }

                transform.rotation = Quaternion.Lerp(transform.rotation, followTarget.transform.rotation, rotationOffset);
                transform.position = Vector3.Lerp(transform.position, followTarget.transform.position, positionOffset);

            }
        }
    }
}
