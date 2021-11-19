using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private void FixedUpdate()
    {
        transform.position = transform.position + Vector3.forward *2* Time.fixedDeltaTime;
    }
}