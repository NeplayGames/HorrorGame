using HorrorGame.NPC;
using UnityEngine;

namespace HorrorGame
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private NPCController nPCController;
        public static GameManager Instance;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(this.gameObject);
            }
            nPCController.OnPlayerDead += OnPlayerDead;
        }

        void Update()
        {
            // if(nPCController?.health == 0){
            //     nPCController.OnPlayerDead();
            //     nPCController = null;
            // }
        }

        public void OnPlayerDead(){
            print("The player is dead");
        }

        void OnDestroy()
        {
            nPCController.OnPlayerDead -= OnPlayerDead;
        }
    }

}
