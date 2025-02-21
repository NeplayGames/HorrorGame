using UnityEngine;
using UnityEngine.AI;

namespace HorrorGame.NPC
{
    public class NPCStateMachine
    {
        private NPCDeadState nPCDeadState;
        private NPCHitState nPCHitState;
        private NPCWanderState nPCWanderState;
        private ENPCState currentState = ENPCState.None;
        private IState state;
        public NPCStateMachine(NavMeshAgent navMeshAgent)
        {
            nPCDeadState = new NPCDeadState();
            nPCHitState = new();
            nPCWanderState = new(navMeshAgent);
            ChangeState(ENPCState.Wander);
        }

        public void ChangeState(ENPCState eNPCState)
        {
            if (currentState == eNPCState || currentState == ENPCState.Dead) return;
            state?.Exit();
            switch (eNPCState)
            {
                case ENPCState.Dead:
                    state = nPCDeadState;
                    break;
                case ENPCState.Hit:
                    state = nPCHitState;
                    break;
                case ENPCState.Wander:
                    state = nPCWanderState;
                    break;
            }
            currentState = eNPCState;
            state.Enter();
        }

        public void RunState(){
            state.Run();
        }
    }

    public enum ENPCState
    {
        None = 4,
        Dead = 0,
        Attack = 3,
        Hit = 1,
        Wander = 2,
    }
}
