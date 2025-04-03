using System;
using HorrorGame.Weapon;
using UnityEngine;
using UnityEngine.UI;

namespace HorrorGame.Player
{
    public class InventoryController
    {
        private AbstractWeapon[] abstractWeapons;
        private int weaponIndex = 0;
        public event Action<Transform> Attach, Detach;
        private WeaponController weaponController;
        public InventoryController(int maxWeapon, WeaponController weaponController)
        {
            abstractWeapons = new AbstractWeapon[maxWeapon];
            this.weaponController = weaponController;
        }

        public void Pick(AbstractWeapon abstractWeapon){
            if(weaponIndex == abstractWeapons.Length)
                weaponIndex = 0;
            if(abstractWeapons[weaponIndex] != null)
                Drop(abstractWeapons[weaponIndex]); 
            abstractWeapons[weaponIndex++] = abstractWeapon;
            Attach?.Invoke(abstractWeapon.transform);
            weaponController.SetCurrentHoldingWeapon(abstractWeapon);
        }

        private void Drop(AbstractWeapon abstractWeapon)
        {
            abstractWeapon.gameObject.SetActive(true);
            Detach?.Invoke(abstractWeapon.transform);
        }
    }

}
