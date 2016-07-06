using UnityEngine;
//using UnityEngine.UI;
//using UnityEngine.SceneManagement;
using System.Collections;
using System;
//using System.Collections.Generic;
//using JMiles42;

public class Crate : PhysicalObject, IHitable
{
    public FixedJoint joint;
    bool noParent = false;

	public override void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag != "vehicle" && !noParent)
        {
            noParent = true;
            transform.SetParent(null);
			OnHit();
        }
    }
}
