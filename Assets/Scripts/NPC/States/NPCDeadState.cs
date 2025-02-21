using UnityEngine;

namespace HorrorGame.NPC
{
    public class NPCDeadState : IState
    {
        public void Enter()
        {
            Debug.Log("dead state");
        }

        public void Exit()
        {

        }

        public void Run()
        {

        }
    }

}
