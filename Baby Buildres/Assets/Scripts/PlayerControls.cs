using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    Renderer myRend;
    float speed = 2f;
    Rigidbody2D playerRb;
    public float thrust;
    bool isGrounded = true;
    public bool canGrab = false;
    public bool isCarrying = false;
    GameObject blockToGrab;

    // Use this for initialization
    void Start()
    {
        myRend = GetComponent<Renderer>();
        myRend.material.color = Color.green;
        playerRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        speed = 2f * Time.deltaTime;
        Controls();


    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (isGrounded)
            {
                playerRb.AddForce(transform.up * thrust);
                isGrounded = false;
            }
        }
    }

    void Controls()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(speed, 0, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-speed, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (canGrab && !isCarrying)
            {
                blockToGrab.transform.parent = this.gameObject.transform;
                blockToGrab.transform.position = new Vector2(transform.position.x, transform.position.y + 1);
                blockToGrab.GetComponent<Rigidbody2D>().isKinematic = true;
                isCarrying = true;
            }
            else if (isCarrying)
            {
                blockToGrab.GetComponent<Rigidbody2D>().isKinematic = false;
                blockToGrab.GetComponent<Rigidbody2D>().AddForce(transform.up * thrust);
                blockToGrab.transform.parent = null;
                isCarrying = false;
            }
        }


    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
        if (col.gameObject.tag == "Block")
        {
			isGrounded = true;
            canGrab = true;
            blockToGrab = col.gameObject;
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if(col.gameObject.tag == "Block")
        {
            canGrab = false;
        }
    }

}
