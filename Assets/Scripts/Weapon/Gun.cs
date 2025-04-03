using HorrorGame.NPC;
using UnityEngine;

namespace HorrorGame.Weapon
{
    public class Gun : AbstractWeapon
    {
        public override void OnEnemyHit(NPCController nPCController)
        {
            nPCController.GetHit(10);
        }
    }
}