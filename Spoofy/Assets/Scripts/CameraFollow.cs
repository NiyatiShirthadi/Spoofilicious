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
    [SerializeField] bool Pink;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        PlayerShadow = GameObject.FindGameObjectWithTag("PlayerShadow");
        Switch = GameObject.FindGameObjectWithTag("Switch");
        Pink = Switch.GetComponent<SwitchKey>().isPink;
    }

    private void LateUpdate()
    {
        if(Pink)
        {
            Debug.Log("Following player");
            Target = Player.transform;
            Vector3 DesiredPosition = Target.position + offset;
            Vector3 SmoothedPosition = Vector3.Lerp(transform.position, DesiredPosition, SmoothSpeed*Time.deltaTime);
            transform.position = SmoothedPosition;
        }
        else if(!Pink)
        {
            Debug.Log("Following shadow");
            Target = PlayerShadow.transform;
            Vector3 DesiredPosition = Target.position + offset;
            Vector3 SmoothedPosition = Vector3.Lerp(transform.position, DesiredPosition, SmoothSpeed * Time.deltaTime);
            transform.position = SmoothedPosition;
        }

    }


}
