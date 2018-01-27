using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float PlayerSpeed = 100f;
    public float JumpIntensity = 10f;
    public int PlayerOneAmmo;
    public int PlayerTwoAmmo;
    public GameObject Weight;

    public bool isOnGround = false;
    public bool CanDoubleJump = false;
    public bool Dead = false;
    public bool CanPickAmmo;
    public GameObject AmmoToPickUp;

    private float horizontalMove;
    private float verticalMove;
    private float playerOneThrowH;
    private float playerOneThrowV;
    private int PlayerOneAmmoBeforePickup;
    private int PlayerTwoAmmoBeforePickup;

    private LineRenderer ThrowLine;
    public float ThrowForce = 10f;

    private Vector2 move = new Vector2();
    private Rigidbody2D myBody;

    public enum Players
    {
        PlayerOne,
        PlayerTwo
    }
    public Players whichPlayer = Players.PlayerOne;

    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
        ThrowLine = GetComponent<LineRenderer>();

        isOnGround = false;
        CanDoubleJump = false;
        Dead = false;
        CanPickAmmo = false;
    }


    void Update()
    {
        playerOneThrowH = Input.GetAxis("PlayerOneThrowH");
        playerOneThrowV = Input.GetAxis("PlayerOneThrowV");

        Move();

        switch (whichPlayer)
        {
            case Players.PlayerOne:
                {
                    if (Input.GetButton("PlayerOneAim"))
                    {
                        Vector3 playerOneAimDirection = new Vector3(playerOneThrowH + transform.position.x, -playerOneThrowV + transform.position.y, -1f);
                        ThrowLine.positionCount = 2;
                        Vector3[] throwLinePosition = new Vector3[] { transform.position, playerOneAimDirection };
                        ThrowLine.SetPositions(throwLinePosition);

                    }
                    if (Input.GetButtonUp("PlayerOneAim") && PlayerOneAmmo > 0)

                    {
                        GameObject LaunchedWeight = Instantiate(Weight, transform.position, Quaternion.identity);
                        LaunchedWeight.GetComponent<Rigidbody2D>().velocity = new Vector2(playerOneThrowH * ThrowForce, -playerOneThrowV * ThrowForce);
                        PlayerOneAmmo--;
                        ThrowLine.SetPositions(new Vector3[] { new Vector3(0f, 0f, 1f), new Vector3(0f, 0f, 1f) });
                    }
                    

                }
                if (CanPickAmmo && Input.GetButtonDown("PlayerOneCatch"))
                {
                    PlayerOneAmmo++;
                    Destroy(AmmoToPickUp);
                }
                    break;
            case Players.PlayerTwo:
                {
                    if (Input.GetButtonUp("PlayerTwoAim") && PlayerTwoAmmo > 0)

                    {
                        GameObject LaunchedWeight = Instantiate(Weight, transform.position, Quaternion.identity);
                        LaunchedWeight.GetComponent<Rigidbody2D>().velocity = new Vector2(3f, 3f);
                        PlayerTwoAmmo--;
                    }
                }
                if (CanPickAmmo && Input.GetButtonDown("PlayerTwoCatch"))
                {
                    PlayerTwoAmmo++;
                    Destroy(AmmoToPickUp);
                }
                break;
        }
        PlayerOneAmmoBeforePickup = PlayerOneAmmo;
        PlayerTwoAmmoBeforePickup = PlayerTwoAmmo;
    }



    private void Move()
    {

        switch (whichPlayer)
        {
            case Players.PlayerOne:

                horizontalMove = Input.GetAxis("PlayerOneHorizontal");
                if (Input.GetButtonDown("PlayerOneJump") && isOnGround == true)
                {

                    myBody.velocity = new Vector2(myBody.velocity.x, JumpIntensity);
                }
                break;
            case Players.PlayerTwo:
                horizontalMove = Input.GetAxis("PlayerTwoHorizontal");
                if (Input.GetButtonDown("PlayerTwoJump") && isOnGround == true)
                {
                    myBody.velocity = new Vector2(myBody.velocity.x, JumpIntensity);
                }
                break;
            default:
                break;
        }


        move.x = horizontalMove;
        myBody.velocity = new Vector2(move.x, myBody.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            isOnGround = true;
        }

        if (col.gameObject.layer == LayerMask.NameToLayer("Ammo"))
        {
            CanPickAmmo = true;
            AmmoToPickUp = col.gameObject;
        }

        switch (whichPlayer)
        {
            case Players.PlayerOne:
                if (col.gameObject.layer == LayerMask.NameToLayer("Pit"))
                {
                    Dead = true;
                }
                break;
            case Players.PlayerTwo:
                if (col.gameObject.layer == LayerMask.NameToLayer("Pit"))
                {
                    Dead = true;
                }
                break;
        }


    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("Ammo"))
        {
            CanPickAmmo = true;
            AmmoToPickUp = col.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            isOnGround = false;
        }

        if (col.gameObject.layer == LayerMask.NameToLayer("Ammo"))
        {
            CanPickAmmo = false;
        }
    }

   

}
