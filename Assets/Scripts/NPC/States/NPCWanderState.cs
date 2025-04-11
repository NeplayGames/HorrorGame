using HorrorGame.NPC;
using HorrorGame.Utils;
using UnityEngine;
using UnityEngine.AI;

namespace HorrorGame.NPC
{
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
            if (navMeshAgent.velocity.magnitude == 0)
            {
                GotoAPoint();
            }
        }

        private void GotoAPoint()
        {          
            this.navMeshAgent.SetDestination(Utilities.GetPointInsideNavmesh());
        }
    }
}