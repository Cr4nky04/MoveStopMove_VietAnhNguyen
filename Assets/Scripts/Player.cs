using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class Player : Character
{
    [SerializeField] private FloatingJoystick floatingJoystick;
    

    private Vector3 targetPosition;
    private Vector3 lookDirection;
    override public void Update()
    {
        base.Update();
        Moving();
        //if (Input.GetKeyDown(KeyCode.J))
        //{
        //    Attack();
        //}
        //if(player_rb.velocity.magnitude < 0.01f)
        //{
        //    isMoving = false;
        //}
        if (!isMoving)
        {
            ChangeAnim("IsIdle");
            if (isAttacking == false && m_Enemies.Count > 0)
            {
                Debug.Log(2);
                isAttacking = true;
                StartCoroutine(Attack());
            }
        }
        else
            ChangeAnim("IsRun");
    }
    private void Moving()
    {
        if(floatingJoystick.Horizontal <0.1f && floatingJoystick.Vertical < 0.1f)
        {
            isMoving = false;
            return;
        }
        isMoving=true;
        //player_rb.velocity = new Vector3(floatingJoystick.Horizontal*moveSpeed, player_rb.velocity.y, floatingJoystick.Vertical*moveSpeed);
        lookDirection = new Vector3(floatingJoystick.Horizontal, 0f, floatingJoystick.Vertical);
        targetPosition = transform.position + lookDirection;
        character_rb.position = Vector3.MoveTowards(character_rb.position, targetPosition, moveSpeed * Time.deltaTime);
        if (floatingJoystick.Horizontal != 0 || floatingJoystick.Vertical != 0)
        {
            character_rb.rotation = Quaternion.LookRotation(lookDirection);
        }
    }
    private void TargetRing()
    {

    }

    
}
