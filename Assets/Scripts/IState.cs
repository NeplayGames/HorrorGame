using UnityEngine;

namespace HorrorGame.NPC
{
    public interface IState
    {
        public void Enter();
        public void Exit();
        public void Run();
    }
}