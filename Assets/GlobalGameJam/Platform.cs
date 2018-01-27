using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {

    public float RotationSpeed;
    public float ReturnSpeed;
    private Quaternion InitialRotation;
    private float lastRotation;
    [Range (0f,1f)]
    public float Inertia;
    public bool ThereIsSomething;
    



	// Use this for initialization
	void Start ()
    {
 
        InitialRotation = transform.rotation;
       
	}
	
	// Update is called once per frame
	void Update ()
    {


        transform.Rotate(0f, 0f, lastRotation);
        lastRotation = Mathf.Lerp(lastRotation, ReturnSpeed *( InitialRotation.z- transform.rotation.z), Inertia);
    }



    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("Players") || col.gameObject.layer == LayerMask.NameToLayer("Ammo") || col.gameObject.layer == LayerMask.NameToLayer("IgnorePlayer"))
        {
            Vector3 RelativePosition = transform.InverseTransformPoint(col.gameObject.transform.position);
            if (RelativePosition.y < 0f)
            {
                col.gameObject.GetComponentInChildren<Collider2D>().isTrigger = true;
            }
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("Players") || col.gameObject.layer == LayerMask.NameToLayer("Ammo") || col.gameObject.layer == LayerMask.NameToLayer("IgnorePlayer"))
        {
            


                col.gameObject.GetComponentInChildren<Collider2D>().isTrigger = false;

        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {


        Vector3 Distance = new Vector3();
        Distance = transform.position - col.transform.position;
        lastRotation += RotationSpeed * col.GetComponent<Rigidbody2D>().mass * Distance.x;
    }

}




