using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;

  
    public Vector3 cockpitOffset = new Vector3(0f, 1.1f, 0.25f);
    public Vector3 chaseOffset = new Vector3(0f, 2.3f, -2.5f);
    public Vector3 topOffset = new Vector3(0f, 7.5f, -1f);

    private int cameraMode = 1; 
    private float smoothSpeed = 6f;

    private Vector3 currentOffset;

    void Start()
    {
        if (!target)
        {
            Debug.LogError("Camera nu are target! Trage masina in campul Target din Inspector.");
            enabled = false;
            return;
        }

      
        currentOffset = chaseOffset;

     
        transform.position = target.TransformPoint(currentOffset);
        transform.LookAt(target);
    }

    void Update()
    {
      
        if (Input.GetMouseButtonDown(0))
        {
            cameraMode++;
            if (cameraMode > 2) cameraMode = 0;

            switch (cameraMode)
            {
                case 0:
                    currentOffset = cockpitOffset;
                    break;
                case 1:
                    currentOffset = chaseOffset;
                    break;
                case 2:
                    currentOffset = topOffset;
                    break;
            }
        }
    }

    void LateUpdate()
    {
        if (!target) return;

       
        Vector3 desiredPosition = target.TransformPoint(currentOffset);

      
        transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * smoothSpeed);

       
        Quaternion desiredRotation = Quaternion.LookRotation(target.position - transform.position, Vector3.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, Time.deltaTime * smoothSpeed);
    }
}
