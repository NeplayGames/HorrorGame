using UnityEngine;

namespace HorrorGame
{
    public class GameManager : MonoBehaviour
    {
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
        }
    }

}
