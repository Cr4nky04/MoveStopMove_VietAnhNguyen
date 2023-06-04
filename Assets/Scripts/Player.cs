using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class Player : Character
{
    [SerializeField] public FloatingJoystick floatingJoystick;
    [SerializeField] private SkinShop skinShop; 

    public Vector3 targetPosition;
    public Vector3 lookDirection;
    

    public override void Awake()
    {
        base.Awake();
    }
    public override void Start()
    {
        base.Start();
        skinShop.Player = this;
        OnInit();

    }
    public string cs;
    
    public override void OnInit()
    {
        base.OnInit();
        currentState.ChangeState(new PlayerIdleState());
    }
    override public void Update()
    {
        cs = currentState.currentState.ToString();
        base.Update();
        Moving();
        Debug.Log("Player" + currentState);
        if(isDeath)
        {

        }
        
    }
    public void Moving()
    {
        //if(floatingJoystick.Horizontal <0.1f && floatingJoystick.Vertical < 0.1f)
        //{
        //    isMoving = false;
        //    return;
        //}
        if(floatingJoystick!=null)
        {
            lookDirection = new Vector3(floatingJoystick.Horizontal, 0f, floatingJoystick.Vertical);

        }
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

    public override void OnDespawn()
    {
        base.OnDespawn();
    }
    public override void KillUp()
    {
        base.KillUp();
        LevelManager.Ins.SetGold(100);
    }

    public override void OnPlayState()
    {
        base.OnPlayState();
        currentState.ChangeState(new PlayerIdleState());
    }
}
