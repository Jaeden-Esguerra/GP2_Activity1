using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public int score = 0;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void addScore(int amount)
    {
        score += amount;
        Debug.Log("Score : " + score);
    }

    public void removeScore(int amount)
    {
        score -= amount;
        Debug.Log("Score: " + score);
    }
}
