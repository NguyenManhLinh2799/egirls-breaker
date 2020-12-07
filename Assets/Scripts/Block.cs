using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    // Config params
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject particleVFX;
    [SerializeField] Sprite[] hitSprites;

    // Cached reference
    Level level;

    // State variables
    [SerializeField] int timesHit; // serialized for debugging purposes

    private void Start()
    {
        level = FindObjectOfType<Level>();
        if (tag == "E-girl")
        {
            level.IncreaseBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        timesHit++;
        int maxHits = hitSprites.Length + 1;
        if (timesHit >= maxHits)
        {
            DestroyBlock();
        }
        else
        {
            ShowNextHitSprite();
        }
    }

    private void ShowNextHitSprite()
    {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("Block sprite is missing from array " + gameObject.name);
        }
    }

    private void DestroyBlock()
    {
        FindObjectOfType<GameSession>().AddToScore();
        TriggerParticleVFX();
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        Destroy(gameObject);
        if (tag == "E-girl")
        {
            level.BlockDestroyed();
        }
    }

    private void TriggerParticleVFX()
    {
        Instantiate(particleVFX, transform.position, transform.rotation);
    }
}
