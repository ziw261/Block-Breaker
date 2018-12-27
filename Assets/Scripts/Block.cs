using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

    // config params
    [SerializeField] int toChangeColor = 0;
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparklesVFX;
    [SerializeField] Sprite[] hitSprites;

    // Cached reference
    Level level;


    // state variables
    [SerializeField] int timesHit;      // TODO only serialized for debug purposes.

    private void Start() {
        CountBreakableBlocks();
       
    }

    private void CountBreakableBlocks() {
        level = FindObjectOfType<Level>();
        if (toChangeColor == 0) {
            if (tag == "Breakable") {
                level.CountBlocks();
            }
        }
    }

    SpriteRenderer specialBox;

    private void OnCollisionEnter2D(Collision2D collision) {
        if (toChangeColor == 0 && tag == "Breakable") {
            HandleHit();
        }
        else if(toChangeColor != 0 ){
            colorToChange();
        }
    }

    private void HandleHit() {
        timesHit++;
        int maxHits = hitSprites.Length + 1;
        if (timesHit >= maxHits) {
            DestroyBlock();
        } else {
            ShowNextHitSprite();
        }
    }

    private void ShowNextHitSprite() {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex] != null) {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        } else {
            Debug.LogError("Block sprite is missing from array");
        }
    }

    private void DestroyBlock() {
        FindObjectOfType<GameSession>().AddToScore();
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        Destroy(gameObject, 0f);
        level.BlockDestroyed();
        TriggerSparklesVFX();
    }

    private void TriggerSparklesVFX() {
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 1f);
    }

    private void colorToChange() {
        
        switch (toChangeColor) {

            case 1:
                changeColor(Color.blue);
                break;
            case 2:
                changeColor(Color.yellow);
                break;
            case 3:
                changeColor(Color.green);
                break;
            case 4:
                changeColor(Color.cyan);
                break;
            case 5:
                changeColor(Color.magenta);
                break;
            case 6:
                changeColor(Color.white);
                break;
            case 7:
                changeColor(Color.gray);
                break;
            case 8:
                changeColor(Color.red);
                break;
        }

    }

    public void changeColor(Color c) {
        Destroy(GetComponent<BoxCollider2D>(), 0f);
        specialBox = GetComponent<SpriteRenderer>();
        specialBox.color = c;
    }
}
