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
            if(Input.GetMouseButtonDown(0)){
                GetHit();
            }   
            nPCStateMachine.RunState(); 
        }

        private void GetHit()
        {
            nPCStateMachine.ChangeState(ENPCState.Hit);
            health -= 10;
            Invoke(nameof(OnAfterHitState), hitTime);
            if(health <= 0)
            OnPlayerDead?.Invoke();
        }

        private void OnAfterHitState(){
             nPCStateMachine.ChangeState(health <= 0 ? ENPCState.Dead : ENPCState.Wander);
        }
    }

}
