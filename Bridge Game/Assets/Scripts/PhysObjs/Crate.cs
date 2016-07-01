using UnityEngine;
//using UnityEngine.UI;
//using UnityEngine.SceneManagement;
using System.Collections;
//using System.Collections.Generic;
//using JMiles42;

public class Crate : MonoBehaviour 
{
    public FixedJoint joint;
    bool noParent = false;

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag != "vehicle" && !noParent)
        {
            print("asdaasdfa");
            noParent = true;
            transform.SetParent(null);
        }
    }
}
