using UnityEngine;
using System.Collections;

public class DeadZone : MonoBehaviour {

    private float mLeftDeadZone = -10.0f;
    private float mRightDeadZone = 10.0f;
    private float mTopDeadZone = 10.0f;
    private float mBottomDeadZone = -10.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (gameObject.transform.position.x < mLeftDeadZone || gameObject.transform.position.x > mRightDeadZone || gameObject.transform.position.y > mTopDeadZone || gameObject.transform.position.y < mBottomDeadZone)
        {
            Destroy(gameObject);
        }
    }
}
