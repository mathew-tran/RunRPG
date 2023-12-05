using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyMoverOnTouch : Mover {

    public override void Setup()
    {
        mMoving = false;
    }
    void OnCollisionStay2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "WALL")
        {
            mMoving = true;
        }
    }
}
