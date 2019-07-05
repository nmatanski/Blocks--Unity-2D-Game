using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStatus : MonoBehaviour
{
    //config params

    [Range(0, 5)]
    [SerializeField]
    public float currentGameSpeed = 0.7f; ///TODO: remove public

    [Range(0, 5)]
    [SerializeField]
    public float defaultGameSpeed = 0.7f; ///TODO: remove public

    [SerializeField]
    private int pointsPerBlockDestroyed = 83;

    //state
    [SerializeField]
    private GameStatusSingleton gameSingleton;
    private float fpsMultiplier = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        //gameSingleton = FindObjectOfType<GameStatusSingleton>();
        gameSingleton = GameObject.Find("Game Status Singleton").GetComponent<GameStatusSingleton>();
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = currentGameSpeed;

        int deltaMultiplier = (int)(20f * (currentGameSpeed - defaultGameSpeed));
        if (deltaMultiplier >= 1)
        {
            fpsMultiplier++;
            if (fpsMultiplier % 60 == 0) // 1 second = 60fps so every second
            {
                pointsPerBlockDestroyed += deltaMultiplier;
            }
        }
    }

    public void IncreaseSpeedBy(float value)
    {
        currentGameSpeed += value;
        if (currentGameSpeed <= 0.35)
        {
            currentGameSpeed = defaultGameSpeed;
        }
    }

    public void AddToScore(int multiplier = 1)
    {
        gameSingleton.currentScore += multiplier * pointsPerBlockDestroyed;
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        gameSingleton.scoreText.text = gameSingleton.currentScore.ToString();
    }
}
