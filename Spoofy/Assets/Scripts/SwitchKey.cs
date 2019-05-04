using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchKey : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] GameObject PlayerShadow;
   
    public Vector3 Offset1;
    public Vector3 Offset2;
    public bool isPink;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        PlayerShadow = GameObject.FindGameObjectWithTag("PlayerShadow");

        Player.GetComponent<PlayerMovement>().enabled = true;
        isPink = true;

        PlayerShadow.GetComponent<ShadowMovement>().enabled = false;
        
    }

    private void ShadowStop()
    {
        Debug.Log("Shadow should stop");
        //PlayerOn
        Player.GetComponent<PlayerMovement>().enabled = true;
        isPink = false;

        //PlayerShadowOff
        PlayerShadow.GetComponent<ShadowMovement>().enabled = false;

        Player.transform.position = PlayerShadow.transform.position + Offset2;
    }

    private void PlayerStop()
    {
        Debug.Log("Player should stop");
        //PlayerShadowOn
        PlayerShadow.GetComponent<ShadowMovement>().enabled = true;
        isPink = true;

        //PlayerOff
        Player.GetComponent<PlayerMovement>().enabled = false;

        PlayerShadow.transform.position = Player.transform.position + Offset1;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (isPink)
            {
                ShadowStop();
                Debug.Log("Shadow should stop");
            }
            else
            {
                Debug.Log("Player should stop");
                PlayerStop();
            }
        }
        
        
              
    }
}
