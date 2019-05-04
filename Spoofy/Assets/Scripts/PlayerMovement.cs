using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float movespeed;
    public float JumpSpeed;
    private float x;
    public bool PlayerisGrounded = false;

    void Start()
    {
       
    }

    
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        Movement(x);
                    
    }

    private void Movement(float x)
    {
        Jump();
        Vector3 movement = new Vector3(x, 0f, 0f);
        //Debug.Log("movement" + movement);
        transform.position += movement * Time.deltaTime * movespeed;
    }

    private void Jump()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow) && PlayerisGrounded)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, JumpSpeed), ForceMode2D.Impulse);
        }
    }

   


}
