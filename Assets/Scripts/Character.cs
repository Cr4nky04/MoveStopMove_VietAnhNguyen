using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
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
    [SerializeField] protected GameObject pant;
    [SerializeField] protected Transform holdWeapon;
    [SerializeField] protected Transform head;
    [SerializeField] protected Transform holdShield;

    private Vector3 direction;
    private string currentAnim;
    private ObjectPooler objectPooler;
    private GameObject currentWeapon;

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
    public WeaponDataList WeaponStats;
    public WeaponData weaponData;
    public WeaponList WeaponList;
    public PantDataList PantStats;
    public PantData PantData;
    public PantList PantList;
    public Material PantMaterial;
    public HairData HairData;
    public HairDataList HairDataList;
    public HairList HairList;
    public ShieldData ShieldData;
    public ShieldDataList ShieldDataList;
    public ShieldList ShieldList;
 

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

    virtual public void Awake()
    {
        PantMaterial = pant.GetComponent<Renderer>().sharedMaterial;
        currentState = new StateMachine<Character>();
        currentState.SetOwner(this);
        //Cache.CharacterList(character);
    }

    virtual public void Start()
    {
        objectPooler = ObjectPooler.Instance;
        ChangeWeapon(WeaponList);
        ChangePant(PantList);
        ChangeHair(HairList);
        ChangeShield(ShieldList);
        
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

        Weapon attackingWeapon = SimplePool.Spawn<Weapon>(WeaponStats.WeaponType, Transform.position+ Vector3.up, Quaternion.Euler(new Vector3(0f,0f,90f)));

        attackingWeapon.parent = this;
        attackingWeapon.TargetPosition = Enemy.Transform.position + Vector3.up;
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
    public void ChangeWeapon(WeaponList weapon)
    {
        Destroy(currentWeapon);
        WeaponStats = weaponData.GetData(weapon);
        currentWeapon = Instantiate(WeaponStats.Prefab,holdWeapon.position,Quaternion.Euler(new Vector3(0f,90f,180f)), holdWeapon);
         
    }
    public void ChangePant(PantList pant)
    {
        this.pant.GetComponent<Renderer>().sharedMaterial = PantData.GetData(pant).Skin;
    }

    public void ChangeHair(HairList hair)
    {
        HairDataList = HairData.GetData(hair);
        Instantiate(HairDataList.Prefab, head.position, Quaternion.identity, head);
    }
    public void ChangeShield(ShieldList shield)
    {
        ShieldDataList = ShieldData.GetData(shield);
        Instantiate(ShieldDataList.Prefab, holdShield.position, Quaternion.identity, holdShield);
    }
}
