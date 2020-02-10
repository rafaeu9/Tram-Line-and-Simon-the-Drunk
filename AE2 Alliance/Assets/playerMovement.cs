using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class playerMovement : MonoBehaviour
{

    private Joystick MyInput;
    private Rigidbody MyRigid;

    public float MoveSpeed;

    void Start()
    {
        MyRigid = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        //Vector3 MoveVec = new Vector3(CrossPlatformInputManager.GetAxis("Horizontal"),0,
        //    CrossPlatformInputManager.GetAxis("Vertical"));

        //if(MoveVec.magnitude > 1)
        //{
        //    MoveVec = MoveVec.normalized;
        //}

        //MyRigid.velocity = MoveVec * MoveSpeed;

        if (Mathf.Abs(CrossPlatformInputManager.GetAxis("RotationHorizontal")) > 0 ||
               Mathf.Abs(CrossPlatformInputManager.GetAxis("RotationVertical")) > 0)
        {
            Vector3 RotVec = new Vector3(CrossPlatformInputManager.GetAxis("RotationHorizontal"),
           CrossPlatformInputManager.GetAxis("RotationVertical"));

            var angle = Mathf.Atan2(RotVec.y, RotVec.x) * Mathf.Rad2Deg;
            angle -= 90;
            transform.rotation = Quaternion.AngleAxis(-angle, Vector3.up);

        }

    }
}
