using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class Vehicle : MonoBehaviour
{
    public float Speed;
    public float Acceleration;
    float m_speed;
    public bool driving;
    public Lane lane;
	
	// Update is called once per frame
	void Update ()
    {
	
	}
}
