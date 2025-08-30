using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;


    void LateUpdate()
    {
        if (!target) return;

        Vector3 desiredPos = transform.position;

        desiredPos.z = target.position.z + offset.z;

        transform.position = desiredPos;
    }
}
