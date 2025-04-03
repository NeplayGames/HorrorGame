using HorrorGame.NPC;
using UnityEngine;

namespace HorrorGame.Weapon
{
    public abstract class AbstractWeapon : MonoBehaviour
    {
        public void Shoot(){
            Vector3 direction = Camera.main.ScreenToWorldPoint(new Vector3( Screen.width / 2, Screen.height /2 , Camera.main.nearClipPlane));
            direction = (direction - Camera.main.transform.position).normalized;
            Debug.DrawLine(Camera.main.transform.position, direction * 1000, Color.red, 5);
            if(Physics.Raycast(Camera.main.transform.position, direction, out RaycastHit hitInfo, 1000)){
                if(hitInfo.collider.TryGetComponent<NPCController>(out NPCController controller)){
                    OnEnemyHit(controller);
                }
            }
        }

        public abstract void OnEnemyHit(NPCController nPCController);
    }
}