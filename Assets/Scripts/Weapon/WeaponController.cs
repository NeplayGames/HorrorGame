using UnityEngine;

namespace HorrorGame.Weapon
{
    public class WeaponController
    {
        private Weapon currentHoldingWeapon;
        public void Shoot(){
            Vector3 direction = Camera.main.ScreenToWorldPoint(new Vector3(Screen.height /2 , Screen.width / 2, 0));
            currentHoldingWeapon?.Shoot(direction);
        }

        public void SetCurrentHoldingWeapon(Weapon weapon){
            currentHoldingWeapon = weapon;
        }
    }

}
