using TMPro;
using UnityEngine;

public class Scoreboard : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreUI;
    public int score;

    private void Start()
    {
        scoreUI = FindAnyObjectByType<TMP_Text>();
    }

    public void AddScore(int amount)
    {
        score += amount;
        Debug.Log("Score: " + score);
        scoreUI.text = "Score: " + score;
    }
}
