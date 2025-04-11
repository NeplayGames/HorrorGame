using System.Collections.Generic;
using HorrorGame.Pooling;
using HorrorGame.Utils;
using UnityEngine;

namespace HorrorGame.NPC
{
    public class NPCManager
    {
        private NPCController nPCController {get;}
        private int npcCount {get;}
        private List<NPCController> nPCControllers = new();
        private PoolingSystem poolingSystem{get;}
        public NPCManager(NPCController nPCController, int npcCount){
            this.nPCController = nPCController;
            this.npcCount = npcCount;
            poolingSystem = new PoolingSystem(nPCController.gameObject);
            InitializeInitialNPC();
        }

        private void InitializeInitialNPC(){
            for(int i = 0; i < npcCount; i++){
                InitializeNPC();
            }
        }

        private void InitializeNPC(){
           GameObject npc = poolingSystem.Request();
           npc.transform.position = Utilities.GetPointInsideNavmesh();
           if(npc.TryGetComponent<NPCController>(out NPCController nPCController)){
            nPCControllers.Add(nPCController);
            nPCController.OnPlayerDead += OnPlayerDead;
           }else{
            Debug.LogWarning($"On {nameof(npc)} we don't have NPC Controller");
           }
        }

        private void OnPlayerDead(NPCController nPCController){
            if(nPCControllers.Contains(nPCController)){
                nPCControllers.Remove(nPCController);
                nPCController.OnPlayerDead -= OnPlayerDead;
                poolingSystem.Return(nPCController.gameObject);
                InitializeNPC();
            }
        }
    }

}
