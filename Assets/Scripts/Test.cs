using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Test : MonoBehaviour
{
    [SerializeField] NavMeshSurface navmeshSurface;
    
    private void Start()
    {
        for(int i =0; i < 10; i++)
        {
            Bot botTest = SimplePool.Spawn<Bot>(PoolType.Bot, Vector3.zero, Quaternion.identity);
            botTest.OnInit();
        }
        
    }
}
