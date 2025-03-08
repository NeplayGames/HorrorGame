using UnityEngine;

namespace HorrorGame.Weapon
{
    public abstract class Weapon : MonoBehaviour
    {
        public abstract void Shoot(Vector3 direction);
    }
}