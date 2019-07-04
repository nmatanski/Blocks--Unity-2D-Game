using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameStatusSingleton : MonoBehaviour
{
    [SerializeField]
    public TextMeshProUGUI scoreText;

    [SerializeField]
    public int currentScore = 0;

    private void Awake()
    {
        int gameSingletonCount = FindObjectsOfType<GameStatusSingleton>().Length;
        if (gameSingletonCount > 1) // if there is already previous gameObject and this is 2nd
        {
            gameObject.SetActive(false); //disable the old one before destroying it so it won't count, because it counts it while destroying it (destroy step is the last and it could take some time, while the new one is created and it's the only 1 alive, but while the old one is not really destroyed yet, it counts it as 2nd)
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

}
