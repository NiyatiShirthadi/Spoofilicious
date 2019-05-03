using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchKey : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] GameObject PlayerShadow;
    public Vector3 Offset1;
    public Vector3 Offset2;
    public bool isPink = false;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        PlayerShadow = GameObject.FindGameObjectWithTag("PlayerShadow");

        Player.GetComponent<PlayerMovement>().enabled = true;
        Player.GetComponent<BoxCollider2D>().enabled = true;
        isPink = true;

        PlayerShadow.GetComponent<ShadowMovement>().enabled = false;
        PlayerShadow.GetComponent<BoxCollider2D>().enabled = false;
    }

    private void ShadowFollow()
    {
        //PlayerOn
        Player.GetComponent<PlayerMovement>().enabled = true;
        Player.GetComponent<BoxCollider2D>().enabled = true;


        PlayerShadow.transform.position = Player.transform.position + Offset1;

        //PlayerShadowOff
        PlayerShadow.GetComponent<ShadowMovement>().enabled = false;
        PlayerShadow.GetComponent<BoxCollider2D>().enabled = false;
    }

    private void PlayerFollow()
    {
        //PlayerShadowOn
        PlayerShadow.GetComponent<ShadowMovement>().enabled = true;
        PlayerShadow.GetComponent<BoxCollider2D>().enabled = true;


        Player.transform.position = PlayerShadow.transform.position + Offset2;

        //PlayerOff
        Player.GetComponent<PlayerMovement>().enabled = false;
        Player.GetComponent<BoxCollider2D>().enabled = false;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (isPink)
            {
                ShadowFollow();
                isPink = false;
            }
            else
            {
                isPink = true;
                PlayerFollow();
            }
        }
        
        
              
    }
}
