using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public float health;
    public float score;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI healthText;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        health = 3;
        scoreText.text = $"Score: {score}";
        healthText.text = $"Health: {health}";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Score()
    {
        score += 50;
        scoreText.text = $"Score: {score}";
    }
}
