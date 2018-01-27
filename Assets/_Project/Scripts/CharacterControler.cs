using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterControler : MonoBehaviour {

    public float m_speedCharacter = 10f;
    public float m_powerOfJump = 10f;
    public int m_numberJump = 2;

    private void Awake()
    {
        m_rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "plateform")
            countJump = 0;
    }


    private void MovePlayer()
    {
        Vector2 move = Vector2.zero;
        move.y = m_rigidbody.velocity.y;

        if ( Input.GetAxisRaw("Horizontal") != 0f )
            move.x = Input.GetAxisRaw("Horizontal") * m_speedCharacter;

        if (countJump < m_numberJump && Input.GetButtonDown("Jump"))
        {
            move.y = m_powerOfJump;
            countJump++;
        }

        m_rigidbody.velocity = move;
    }


    private Rigidbody2D m_rigidbody;
    private int countJump = 0;
}
