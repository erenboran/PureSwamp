using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField]
    Transform _target;

    [SerializeField]
    float _smoothSpeed = 0.125f;

    [SerializeField]
    Vector3 _offset;

    void FixedUpdate()
    {
       
        Vector3 desiredPosition = _target.position + _offset;

        desiredPosition.z = transform.position.z;
        desiredPosition.y = transform.position.y;

        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, _smoothSpeed);

        transform.position = smoothedPosition;
    }
}
