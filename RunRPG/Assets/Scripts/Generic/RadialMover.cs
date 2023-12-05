using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadialMover : MonoBehaviour {

    public float mRotation = 0.0f;
    public float mSpeed = 5.0f;

    public void SetRotation(float rotation)
    {
        Quaternion rot = gameObject.transform.rotation;
        rot.z = mRotation;
        gameObject.transform.Rotate(0.0f, 0.0f, rotation);
    }
    public void Start()
    {
        SetRotation(mRotation);
    }
    public void Update()
    {
        gameObject.transform.Translate(Vector3.right * mSpeed * Time.deltaTime);
    }
}
