using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering.VirtualTexturing;
using static UnityEngine.EventSystems.EventTrigger;

public class Character : GameUnit
{
    [SerializeField] protected float atkRange = 10f;
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
    [SerializeField] protected List<ParticleSystem> particleVFX;

    private Vector3 direction;
    private string currentAnim;
    private ObjectPooler objectPooler;
    private GameObject currentWeapon;
    private GameObject currentHair;
    private int pointLimit;
    private float scaleRange;

    private float defaultATKRange = 2f;
    public float ATKRange;
    private float defaultAttackSpeed = 2f;
    private Vector3 defaultRingSize;

    public bool isDeath = false;
    public AttackRing AttackRing;
    public GameObject Ring;
    public float ResetAttackTime;
    public StateMachine<Character> currentState;
    public Rigidbody character_rb;
    public bool isAttacking = false;
    public bool isMoving;
    public float WeaponSpeed = 5f;
    public float AttackSpeed = 2f;
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
    public TargetRing TargetRing;
    public MissionWaypoint waypoint;
    public MissionWaypoint MissionWaypointPrefab;
    public Transform CanvasMissionWaypoint;
    public int Point;
    public float WeaponScale;
    public string charName;
    public Material ColorMaterial;
    public SkinnedMeshRenderer skinnedMeshRenderer;

    protected string currentAnimName = "";
    protected float score;
    public Transform Transform
    {
        get
        {
            if (m_Transform == null)
                m_Transform = transform;
            return m_Transform;
        }
    }

    virtual public void Awake()
    {
        defaultATKRange = AttackRing.GetComponent<SphereCollider>().radius;
        ATKRange = defaultATKRange;
        defaultRingSize = Ring.GetComponent<Transform>().localScale;
        PantMaterial = pant.GetComponent<Renderer>().sharedMaterial;
        currentState = new StateMachine<Character>();
        currentState.SetOwner(this);
        //Cache.CharacterList(character);
    }

    virtual public void Start()
    {
        currentState.ChangeState(new NoneState());
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
        CheckScale();

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

        ChangeAnim(Cache.ANIM_ATTACK);
        yield return Cache.GetWFS(0.3f);

        Weapon attackingWeapon = SimplePool.Spawn<Weapon>(WeaponStats.WeaponType, Transform.position + Vector3.up, Quaternion.Euler(new Vector3(0f, 0f, 90f)));

        attackingWeapon.parent = this;
        attackingWeapon.TargetPosition = ATKRange * (Enemy.Transform.position + Vector3.up - Transform.position).normalized + Transform.position;
        attackingWeapon.OnInit();

        yield return Cache.GetWFS(AttackSpeed);
        isAttacking = false;
        //attackingWeapon.OnDespawn();
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
        SimplePool.Despawn(waypoint);
        onDespawnCallback?.Invoke(this);

        /// Clear all function in callback
        onDespawnCallback = null;
    }

    public override void OnInit()
    {
        Transform.localScale = Vector3.one;
        waypoint = SimplePool.Spawn<MissionWaypoint>(MissionWaypointPrefab, Transform.position + Vector3.up, Quaternion.identity);
        waypoint.target = Transform;
        waypoint.ShowPoint(waypoint.Point = Point);
        pointLimit = 2;
        scaleRange = 1.25f;
        WeaponScale = 1f;
        charName = NameList.AddRandomName();
        waypoint.ShowName(charName);

        float r = UnityEngine.Random.Range(0f, 255f) / 255f;
        float g = UnityEngine.Random.Range(0f, 255f) / 255f;
        float b = UnityEngine.Random.Range(0f, 255f) / 255f;
        //TODO: khong duoc change material.color
        skinnedMeshRenderer.material.color = new Color(r, g, b);
        waypoint.Indicator.color = skinnedMeshRenderer.material.color;
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
        currentWeapon = Instantiate(WeaponStats.HandWeapon, holdWeapon.position, Quaternion.Euler(new Vector3(0f, 90f, 180f)), holdWeapon);
        ChangeAttackRing(WeaponStats.ATKRangeScalar);
        ChangeAttackSpeed(WeaponStats.AttackSpeed);
    }
    public void ChangeWeapon(int weapon)
    {
        Destroy(currentWeapon);
        WeaponStats = weaponData.GetData((WeaponList)weapon);
        currentWeapon = Instantiate(WeaponStats.HandWeapon, holdWeapon.position, Quaternion.Euler(new Vector3(0f, 90f, 180f)), holdWeapon);
        ChangeAttackRing(WeaponStats.ATKRangeScalar);
        ChangeAttackSpeed(WeaponStats.AttackSpeed);
    }
    public void ChangePant(PantList pant)
    {
        this.pant.GetComponent<Renderer>().sharedMaterial = PantData.GetData(pant).Skin;
    }

    public void ChangeHair(HairList hair)
    {
        Destroy(currentHair);
        HairDataList = HairData.GetData(hair);
        currentHair = Instantiate(HairDataList.Prefab, head.position, Quaternion.identity, head);
    }
    public void ChangeShield(ShieldList shield)
    {
        ShieldDataList = ShieldData.GetData(shield);
        Instantiate(ShieldDataList.Prefab, holdShield.position, Quaternion.identity, holdShield);
    }
    public void ChangeAttackRing(float scalar)
    {
        AttackRing.GetComponent<SphereCollider>().radius = defaultATKRange * (100 + scalar) / 100;
        ATKRange = defaultATKRange * (100 + scalar) / 100;
        Ring.GetComponent<Transform>().localScale = defaultRingSize * (100 + scalar) / 100;
        Debug.Log(defaultATKRange + "default");
        Debug.Log(scalar + "scalar");
        Debug.Log(ATKRange);
        Debug.Log("Change");
    }
    public void ChangeAttackSpeed(float scalar)
    {
        AttackSpeed = defaultAttackSpeed * (100 - scalar) / 100;
    }

    public void OnScale(float value)
    {
        Transform.localScale *= value;
        WeaponScale *= 1.25f;
        ATKRange *= 1.25f;
    }

    public void CheckScale()
    {
        if (Point > pointLimit)
        {
            OnScale(scaleRange);
            pointLimit *= 2;

        }

    }

    public virtual void Stop()
    {
    }

    protected virtual void OnDeath()
    {
        currentState.ChangeState(new DeathState());
        isDeath = true;
        Alive.Ins.ShowRemain(LevelManager.Ins.EnemyRemain--);
        
    }

    public virtual void KillUp()
    {
        Point += 1;
        waypoint.ShowPoint(waypoint.Point = Point);

    }

    internal void OnHit()
    {
        OnDeath();
        ParticlePool.Play(particleVFX[0], Transform.position, Quaternion.identity);
    }

    public virtual void OnPlayState()
    {

    }
}