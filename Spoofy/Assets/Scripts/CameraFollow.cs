using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Target;
    public float SmoothSpeed = 0.125f;
    public Vector3 offset;
    [SerializeField] GameObject Player;
    [SerializeField] GameObject PlayerShadow;
    [SerializeField] GameObject Switch;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        PlayerShadow = GameObject.FindGameObjectWithTag("PlayerShadow");
        Switch = GameObject.FindGameObjectWithTag("Switch");
    }

    private void LateUpdate()
    {
        if(Switch.GetComponent<SwitchKey>().isPink == true)
        {
            Target = Player.transform;
            Vector3 DesiredPosition = Target.position + offset;
            Vector3 SmoothedPosition = Vector3.Lerp(transform.position, DesiredPosition, SmoothSpeed*Time.deltaTime);
            transform.position = SmoothedPosition;
        }
        else if(Switch.GetComponent<SwitchKey>().isPink == false)
        {
            Target = PlayerShadow.transform;
            Vector3 DesiredPosition = Target.position + offset;
            Vector3 SmoothedPosition = Vector3.Lerp(transform.position, DesiredPosition, SmoothSpeed * Time.deltaTime);
            transform.position = SmoothedPosition;
        }

    }


}
