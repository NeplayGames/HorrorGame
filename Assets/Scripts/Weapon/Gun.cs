using UnityEngine;

namespace HorrorGame.Weapon
{
    public class Gun : Weapon
    {
        public override void Shoot(Vector3 direction)
        {
           print("Gun Shoot");
        }
    }
}