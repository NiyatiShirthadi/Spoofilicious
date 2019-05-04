using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowMovement : MonoBehaviour
{

    public float Shadowmovespeed;
    public float ShadowJumpSpeed;
    private float x;
    public bool isShadowGrounded;

    void Start()
    {
       
    }

    
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        ShMovement(x);
                    
    }

    private void ShMovement(float x)
    {
        Jump();
        Vector3 movement = new Vector3(x, 0f, 0f);
        Debug.Log("Shadow movement" + movement);
        transform.position += movement * Time.deltaTime * Shadowmovespeed;
    }

    private void Jump()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow) && isShadowGrounded)
        {
            Debug.Log("Jump Shadow");
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, ShadowJumpSpeed), ForceMode2D.Impulse);
        }
    }

   


}
