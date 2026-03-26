using UnityEngine;
using TMPro;

namespace VectorFlux
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }

        public int score = 0;
        public string currentTrick = "WAITING_FOR_DATA";

        void Awake()
        {
            if (Instance == null) Instance = this;
            else Destroy(gameObject);
        }

        public void AddScore(int amount)
        {
            score += amount;
            Debug.Log($"Score updated: {score}");
        }

        public void UpdateTrick(string name)
        {
            currentTrick = name;
        }

        public void OnOllie()
        {
            UpdateTrick("HYDRO_OLLIE");
        }
    }
}
