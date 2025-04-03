using UnityEngine;

namespace HorrorGame.Weapon
{
    public class WeaponController
    {
        private AbstractWeapon currentHoldingWeapon;
        public void Shoot(){
            currentHoldingWeapon?.Shoot();
        }

        public void SetCurrentHoldingWeapon(AbstractWeapon weapon){
            if(currentHoldingWeapon != null){
                currentHoldingWeapon.gameObject.SetActive(false);
            }
            currentHoldingWeapon = weapon;
        }
    }

}
