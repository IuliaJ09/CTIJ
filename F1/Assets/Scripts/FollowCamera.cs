using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;

    // Offset-uri pentru cele trei perspective
    public Vector3 cockpitOffset = new Vector3(0f, 1.1f, 0.25f);
    public Vector3 chaseOffset = new Vector3(0f, 2.3f, -2.5f);
    public Vector3 topOffset = new Vector3(0f, 7.5f, -1f);

    private int cameraMode = 1; // 0=cockpit, 1=chase, 2=top
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

        // Setează offsetul curent
        currentOffset = chaseOffset;

        // ✅ Setează camera direct la poziția inițială corectă
        transform.position = target.TransformPoint(currentOffset);
        transform.LookAt(target);
    }

    void Update()
    {
        // Schimbă perspectiva la click stânga
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

        // Poziția dorită a camerei (relativ la mașină)
        Vector3 desiredPosition = target.TransformPoint(currentOffset);

        // Tranziție lină
        transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * smoothSpeed);

        // Orientare lină către mașină
        Quaternion desiredRotation = Quaternion.LookRotation(target.position - transform.position, Vector3.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, Time.deltaTime * smoothSpeed);
    }
}
