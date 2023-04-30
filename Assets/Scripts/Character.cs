using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;

public class Character : MonoBehaviour
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

    public float ResetAttackTime;
    public GameStateManager<Character> currentState;
    public Rigidbody character_rb;
    public bool isAttacking = false;
    public bool isMoving;
    public float atkSpeed = 5f; 
    public Character Enemy;
    public List<Character> m_Enemies;
    public string Name;

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
        currentState = new GameStateManager<Character>();
        currentState.SetOwner(this);
    }

    virtual public void Start()
    {

    }
    virtual public void Update()
    {
        //Attack();

        this.UpdateCharacterState();


    }

    //virtual public void Attack()
    //{




    //}
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
        Debug.Log("Attack");
        Enemy = m_Enemies[0];
        direction = Enemy.Transform.position - Transform.position;
        direction = direction.normalized;
        Transform.LookAt(Enemy.Transform);
        ChangeAnim("IsAttack");
        Weapon attackingWeapon = Instantiate(weapon, Transform.position + 1.5f * direction, Quaternion.identity);
        attackingWeapon.parent = character;
        attackingWeapon.TargetPosition = Enemy.Transform.position;
        yield return Cache.GetWFS(3f);
        isAttacking=false;
    }
    public bool CheckAnimationFinish()
    {
        return (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !anim.IsInTransition(0));
    }
}
