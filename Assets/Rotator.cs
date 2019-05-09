using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float rotateSpeed = 1f;

    void Update()
    {
        transform.Rotate(new Vector3(0f, Time.deltaTime * rotateSpeed, 0f));
    }
}
