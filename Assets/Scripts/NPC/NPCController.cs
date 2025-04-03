using System;
using UnityEngine;
using UnityEngine.AI;

namespace HorrorGame.NPC
{
    public class NPCController : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent navMeshAgent;
        public int health = 100;
        public float hitTime = 2;
        private NPCStateMachine nPCStateMachine;

        public event Action OnPlayerDead;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            nPCStateMachine = new NPCStateMachine(navMeshAgent);
        }

        // Update is called once per frame
        void Update()
        { 
            nPCStateMachine.RunState(); 
        }

        public void GetHit(int damage)
        {
            nPCStateMachine.ChangeState(ENPCState.Hit);
            health -= damage;
            Invoke(nameof(OnAfterHitState), hitTime);
            if(health <= 0)
            OnPlayerDead?.Invoke();
        }

        private void OnAfterHitState(){
             nPCStateMachine.ChangeState(health <= 0 ? ENPCState.Dead : ENPCState.Wander);
        }
    }

}
