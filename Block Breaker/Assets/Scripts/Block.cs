using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField]
    private AudioClip breakSound;

    [Range(0,10)]
    [SerializeField]
    private int pointsMultiplier = 1;

    [SerializeField]
    GameObject blockSparklesVFX;

    //cached component refs
    private Level level;
    private GameStatus game;

    private void Start()
    {
        level = FindObjectOfType<Level>();
        level.IncrementBreakableBlocks();
        game = FindObjectOfType<GameStatus>();
    }

    private void OnCollisionEnter2D(Collision2D collision) //collision.gameObject will be the Ball object
    {
        DestroyBlock();
        TriggerSparklesVFX();
    }

    private void DestroyBlock()
    {
        PlayBlockDestroySFX();
        Destroy(gameObject);
        level.OnBlockDestroy();
        game.AddToScore(pointsMultiplier);
        TriggerSparklesVFX();
    }

    private void PlayBlockDestroySFX()
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
    }

    private void TriggerSparklesVFX()
    {
        var sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 2f);
    }
}
