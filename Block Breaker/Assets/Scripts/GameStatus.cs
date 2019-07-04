using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatus : MonoBehaviour
{
    [Range(0, 5)]
    [SerializeField]
    private float currentGameSpeed = 0.7f;

    [Range(0, 5)]
    [SerializeField]
    private float defaultGameSpeed = 0.7f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = currentGameSpeed;
    }

    public void IncreaseSpeedBy(float value)
    {
        currentGameSpeed += value;
        if (currentGameSpeed <= 0.35)
        {
            currentGameSpeed = defaultGameSpeed;
        }
    }
}
