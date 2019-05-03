using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowGrounded : MonoBehaviour
{
    public GameObject Shadow;
    // Start is called before the first frame update
    void Start()
    {
        Shadow = gameObject.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "GroundShadow")
        {
            Debug.Log("ShadowGround is true");
            Shadow.GetComponent<ShadowMovement>().isShadowGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "GroundShadow")
        {
            Debug.Log("ShadowGround is false");
            Shadow.GetComponent<ShadowMovement>().isShadowGrounded = false;
        }
    }
}
