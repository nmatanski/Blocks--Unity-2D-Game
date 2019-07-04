using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField]
    private AudioClip breakSound;

    //cached component refs
    private Level level;

    private void Start()
    {
        level = FindObjectOfType<Level>();
        level.IncrementBreakableBlocks();
    }

    private void OnCollisionEnter2D(Collision2D collision) //collision.gameObject will be the Ball object
    {
        DestroyBlock();
    }

    private void DestroyBlock()
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        Destroy(gameObject);
        level.OnBlockDestroy();
    }
}
