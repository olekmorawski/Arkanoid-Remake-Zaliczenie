using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] GameObject blockSparkles;
    [SerializeField] AudioClip breakSound;
    [SerializeField] int maxHits;
    [SerializeField] int timesHit;
    [SerializeField] Sprite[] hitSprites;
    Level level;

    private void Start()
    {
        CountBreakableBlocks();
    }

    private void CountBreakableBlocks()
    {
     //   level = FindObjectOfType<Level>();
        if (tag == "Breakable")
        {
        //    level.CountBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            HandleHit();
        }
    }

    private void HandleHit()
    {
        timesHit++;
        if (timesHit >= maxHits)
        {
            DestroyBlock();
        }
        else
        {
            ShowNextHitSprites();
        }
    }

    private void ShowNextHitSprites()
    {
        int spriteIndex = timesHit - 1;
        GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
    }

    private void DestroyBlock()
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        TriggerParticles();
        gameObject.transform.parent = null;
        Level.instance.CheckBlocks();
        Destroy(gameObject);
    }
    private void TriggerParticles()
    {
        GameObject sparkles = Instantiate(blockSparkles, transform.position, transform.rotation);
        Destroy(sparkles, 1f);
    }
}
