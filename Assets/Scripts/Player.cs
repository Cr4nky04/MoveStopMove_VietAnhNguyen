using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    [SerializeField] private FloatingJoystick floatingJoystick;
    [SerializeField] private Rigidbody player_rb;

    private Vector3 targetPosition;
    private Vector3 lookDirection;
    override public void Update()
    {
        base.Update();
        Moving();
        if(Input.GetKeyDown(KeyCode.J))
        {
            Attack();
        }
            
    }
    private void Moving()
    {
        //player_rb.velocity = new Vector3(floatingJoystick.Horizontal*moveSpeed, player_rb.velocity.y, floatingJoystick.Vertical*moveSpeed);
        lookDirection = new Vector3(floatingJoystick.Horizontal, 0f, floatingJoystick.Vertical);
        targetPosition = transform.position + lookDirection;
        player_rb.position = Vector3.MoveTowards(player_rb.position, targetPosition, moveSpeed * Time.deltaTime);
        if (floatingJoystick.Horizontal != 0 || floatingJoystick.Vertical != 0)
        {
            player_rb.rotation = Quaternion.LookRotation(lookDirection);
        }
    }
    private void TargetRing()
    {

    }

    
}
