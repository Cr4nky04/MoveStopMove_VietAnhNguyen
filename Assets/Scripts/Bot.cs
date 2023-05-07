using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bot : Character
{
    [SerializeField] private Bounds mapBound;
    [SerializeField] private NavMeshAgent bot;
    [SerializeField] private GameObject floor;
    [SerializeField] private GameObject destination;

    public Vector3 destinationPosition;

    public override void Start()
    {
        base.Start();

        currentState.ChangeState(new BotIdleState());

    }

    public override void Update()
    {
        base.Update();
        //if(!isMoving)
        //{
        //    isMoving = true;
        //    MovingRandom();
        //    ChangeAnim("Run");
        //}
        //if(Vector3.Distance(Transform.position, destinationPosition) < 2f)
        //{
        //    ChangeAnim("Idle");
        //    isMoving = false;
        //    SeekRandomPoint();
            
        //}
    }

    public void MovingRandom()
    {
         bot.SetDestination(destinationPosition);
        //destination.transform.position = destinationPosition;
    }

    public void SeekRandomPoint()
    {
        destinationPosition.x = Random.Range(mapBound.min.x, mapBound.max.x);
        destinationPosition.y = mapBound.max.y+1f;
        destinationPosition.z = Random.Range(mapBound.min.z, mapBound.max.z);
    }

    public override void OnInit()
    {
        base.OnInit();
        mapBound = floor.GetComponent<Renderer>().bounds;
        Vector3 startPosition = new Vector3();
        startPosition.x = Random.Range(mapBound.min.x, mapBound.max.x);
        startPosition.y = Transform.position.y;
        startPosition.z = Random.Range(mapBound.min.z, mapBound.max.z);
        Transform.position = startPosition;
    }
}
