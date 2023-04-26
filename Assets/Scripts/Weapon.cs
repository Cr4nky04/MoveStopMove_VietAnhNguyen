using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Weapon : MonoBehaviour
{
    [SerializeField] protected Transform m_Transform;
    [SerializeField] Player player;

    public Character character;

    public Vector3 TargetPosition;
    public Transform Transform
    {
        get
        {
            if (m_Transform == null)
                m_Transform = transform;
            return m_Transform;
        }
    }

    private void Update()
    {
        Transform.position = Vector3.MoveTowards(Transform.position, TargetPosition, character.atkSpeed*Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if(other.CompareTag("Character"))
        {
            Destroy(other.gameObject);
            Destroy(Transform.gameObject);
        }
    }

   

}
