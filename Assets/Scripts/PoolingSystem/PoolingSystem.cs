
using System.Collections.Generic;
using UnityEngine;

namespace HorrorGame.Pooling
{
    public class PoolingSystem
    {
        private Stack<GameObject> pooledGameObject = new Stack<GameObject>();

        private GameObject gameObject { get; }

        public PoolingSystem(GameObject gameObject)
        {
            this.gameObject = gameObject;
        }

        public GameObject Request()
        {
            GameObject go;
            if (pooledGameObject.Count == 0)
            {
                go = GameObject.Instantiate(gameObject);
            }
            else
                go = pooledGameObject.Pop();
            go.SetActive(true);
            return go;
        }

        public void Return(GameObject gameObject)
        {
            gameObject.SetActive(false);
            pooledGameObject.Push(gameObject);
        }
    }

}
