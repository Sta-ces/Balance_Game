using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlateformComeBack : MonoBehaviour {

    //public float m_OriginRotation = 0;
    public float m_timeToInitialiseRotation = 5f;

    private void Awake()
    {
        m_rigidbody = GetComponent<Rigidbody2D>();
        m_InitialRotation = m_rigidbody.rotation;
    }

    private void FixedUpdate()
    {
        //m_rigidbody.rotation = m_OriginRotation;
        m_rigidbody.angularVelocity = m_InitialRotation;
        if (!isPlayerOnPlateform)
        {
            //float lastRotation = Mathf.LerpAngle(m_rigidbody.rotation, m_InitialRotation, m_timeToInitialiseRotation);
        }
    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
            isPlayerOnPlateform = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
            isPlayerOnPlateform = false;
    }

    private Rigidbody2D m_rigidbody;
    private float m_InitialRotation;
    private bool isPlayerOnPlateform = false;
}
