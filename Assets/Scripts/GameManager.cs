using HorrorGame.NPC;
using UnityEngine;

namespace HorrorGame
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private NPCController nPCController;
        [SerializeField, Range(4, 100)] private int npcCount = 10;
        private NPCManager nPCManager;
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
            nPCManager = new(nPCController, npcCount);
        }

        void Update()
        {
            // if(nPCController?.health == 0){
            //     nPCController.OnPlayerDead();
            //     nPCController = null;
            // }
        }

        void OnDestroy()
        {
        }
    }

}
