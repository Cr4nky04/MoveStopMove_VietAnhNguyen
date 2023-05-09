using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering.VirtualTexturing;

public class Character : GameUnit
{
    [SerializeField] public float atkRange=10f;
    [SerializeField] protected float sizeScale;
    [SerializeField] protected float moveSpeed;
    [SerializeField] protected Transform m_Transform;
    [SerializeField] protected Weapon weapon;
    [SerializeField] protected Character character;
    [SerializeField] protected Animator anim;

    private Vector3 direction;
    private string currentAnim;
    private ObjectPooler objectPooler;

    public float ResetAttackTime;
    public StateMachine<Character> currentState;
    public Rigidbody character_rb;
    public bool isAttacking = false;
    public bool isMoving;
    public float atkSpeed = 5f; 
    public Character Enemy;
    public List<Character> m_Enemies;
    public string Name;
    public UnityAction<Character> onDespawnCallback;

    protected string currentAnimName = "";
    protected float score;
    public Transform Transform
    {
        get
        {
            if(m_Transform==null)
                m_Transform = transform;
            return m_Transform;
        }
    }

    private void Awake()
    {
        currentState = new StateMachine<Character>();
        currentState.SetOwner(this);
        //Cache.CharacterList(character);
        
    }

    virtual public void Start()
    {
        objectPooler = ObjectPooler.Instance;
    }
    virtual public void Update()
    {
        //Attack();

        this.UpdateCharacterState();


    }


    virtual protected void UpdateCharacterState()
    {
        currentState.UpdateState(this);
    }

    public void ChangeAnim(string animName)
    {

        if (currentAnim != animName)
        {
            Debug.Log(animName);
            anim.ResetTrigger(currentAnim);
            currentAnim = animName;
            anim.SetTrigger(currentAnim);

        }
    }

    public IEnumerator Attack()
    {
        Enemy = m_Enemies[0];
        

        //direction = Enemy.Transform.position - Transform.position;
        //direction = direction.normalized;

        ChangeAnim(Cache.AnimName("IsAttack"));
        yield return Cache.GetWFS(0.3f);

        Weapon attackingWeapon = SimplePool.Spawn<Weapon>(PoolType.Brick, Transform.position, Quaternion.identity);

        attackingWeapon.parent = this;
        attackingWeapon.TargetPosition = Enemy.Transform.position;
        attackingWeapon.OnInit();

        yield return Cache.GetWFS(2f);
        isAttacking=false;
        attackingWeapon.OnDespawn();
    }
    public bool CheckAnimationFinish()
    {
        return (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !anim.IsInTransition(0));
    }
    public void OnRotate()
    {

    }
    public override void OnDespawn()
    {
        SimplePool.Despawn(this);
        onDespawnCallback?.Invoke(this);

        /// Clear all function in callback
        onDespawnCallback = null;
    }

    public override void OnInit()
    {
        
    }
    public void AddCharacter(Character character)
    {
        if (m_Enemies.Contains(character)) return;
        m_Enemies.Add(character);

        /// Add function to call back
        character.onDespawnCallback += RemoveCharacter;
    }
    public void RemoveCharacter(Character character)
    {
        /// Debug.Log($"{gameObject.name} remove {character.gameObject.name}");
        if (!m_Enemies.Contains(character)) return;
        m_Enemies.Remove(character);

        /// Remove callback after character despawn
        onDespawnCallback -= character.RemoveCharacter;
    }

    public void Despawn()
    {
        gameObject.SetActive(false);
        onDespawnCallback?.Invoke(this);

        /// Clear all function in callback
        onDespawnCallback = null;
    }
}
