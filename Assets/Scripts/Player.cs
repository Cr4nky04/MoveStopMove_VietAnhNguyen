using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class Player : Character
{
    [SerializeField] public FloatingJoystick floatingJoystick;
    [SerializeField] WeaponData weaponData;


    public Vector3 targetPosition;
    public Vector3 lookDirection;

    public override void Start()
    {
        base.Start();
        currentState.ChangeState(new PlayerIdleState());
        weaponData.GetData(WeaponList.hammer);

    }
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
        //if (!isMoving)
        //{

        //    if (isAttacking == false && m_Enemies.Count == 0)
        //    {
        //        ChangeAnim("IsIdle");
        //    }

        //}
        //if(isMoving)
        //    ChangeAnim("IsRun");
    }
    public void Moving()
    {
        //if(floatingJoystick.Horizontal <0.1f && floatingJoystick.Vertical < 0.1f)
        //{
        //    isMoving = false;
        //    return;
        //}

        lookDirection = new Vector3(floatingJoystick.Horizontal, 0f, floatingJoystick.Vertical);
        //if (Vector3.Distance(lookDirection, Vector3.zero) < 0.1f && !isAttacking)
        //{
        //    isMoving = false;
        //    ChangeAnim(Cache.AnimName("IsIdle"));
        //    if ( m_Enemies.Count > 0)
        //    {
        //        Debug.Log(2);
        //        isAttacking = true;
        //        StartCoroutine(Attack());
        //    }
        //}


        if (Vector3.Distance(lookDirection, Vector3.zero) > 0.1f)
        {
            isMoving = true;
            //player_rb.velocity = new Vector3(floatingJoystick.Horizontal*moveSpeed, player_rb.velocity.y, floatingJoystick.Vertical*moveSpeed);
            ChangeAnim(Cache.AnimName("IsRun"));
            character_rb.rotation = Quaternion.LookRotation(lookDirection);

        }
        targetPosition = transform.position + lookDirection;
        character_rb.position = Vector3.MoveTowards(character_rb.position, targetPosition, moveSpeed * Time.deltaTime);

    }
    private void TargetRing()
    {

    }


}
