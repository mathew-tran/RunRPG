using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

    // Use this for initialization
    public float mSpeed = 2.5f;

    public bool mMoving;
	void Start () {
        mMoving = true;
        Setup();
	}
	public virtual void Setup()
    {

    }
	// Update is called once per frame
	public void Update ()
    {
        if(mMoving)
            transform.Translate(Vector3.right * Time.deltaTime * mSpeed);
	}
}
