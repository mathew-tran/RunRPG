using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour
{

    public float mTimeToLive = .50f;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (mTimeToLive > 0)
        {
            mTimeToLive -= Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
