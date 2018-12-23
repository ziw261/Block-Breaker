using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

    [SerializeField] int toChangeColor = 0;
    SpriteRenderer specialBox;

    private void OnCollisionEnter2D(Collision2D collision) {
        if (toChangeColor == 0) {
            Destroy(gameObject, 0f);
        } else {
            if (toChangeColor == 1) {
                changeColor(Color.blue);
            } else if (toChangeColor == 2) {
                changeColor(Color.yellow);
            } else if (toChangeColor == 3) {
                changeColor(Color.green);
            } else if (toChangeColor == 4){
                changeColor(Color.cyan);
            } else if (toChangeColor == 5) {
                changeColor(Color.magenta);
            } else if (toChangeColor == 6) {
                changeColor(Color.white);
            } else if (toChangeColor == 7) {
                changeColor(Color.gray);
            } else if (toChangeColor == 8) {
                changeColor(Color.red);
            }
        }
    }

    public void changeColor(Color c) {
        Destroy(GetComponent<BoxCollider2D>(), 0f);
        specialBox = GetComponent<SpriteRenderer>();
        specialBox.color = c;
    }
}
