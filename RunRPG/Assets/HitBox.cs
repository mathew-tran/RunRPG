using UnityEngine;
using System.Collections;

public class HitBox : MonoBehaviour {

    // Use this for initialization
    public Damageable mDamageable;
    public string mDamageTag;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnCollisionStay2D(Collision2D other)
    {
        Debug.Log(other.collider.name);
        if(other.gameObject.tag == mDamageTag)
        {
            mDamageable.TakeDamage(1);
        }
    }
}
