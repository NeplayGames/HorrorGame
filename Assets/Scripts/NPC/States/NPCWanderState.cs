using HorrorGame.NPC;
using UnityEngine;
using UnityEngine.AI;

public class NPCWanderState : IState
{
    private NavMeshAgent navMeshAgent;

    public NPCWanderState(NavMeshAgent navMeshAgent)
    {
        this.navMeshAgent = navMeshAgent;
    }

    public void Enter()
    {    
          GotoAPoint(); 
    }

    public void Exit()
    {
    }

    public void Run()
    {
        if(navMeshAgent.velocity.magnitude == 0){
            GotoAPoint();
        }
    }

    private void GotoAPoint(){
        Vector3 point = Random.insideUnitSphere * 5;
        this.navMeshAgent.SetDestination(point);
    }
}
