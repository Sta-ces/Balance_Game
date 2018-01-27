using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weight : MonoBehaviour {

    public bool Pickable = false;
    public Rigidbody2D MyBody;


	void Start ()
    {
        Pickable = false;
        MyBody = gameObject.GetComponent<Rigidbody2D>();
	}
	

	void Update ()
    {

	}
}
