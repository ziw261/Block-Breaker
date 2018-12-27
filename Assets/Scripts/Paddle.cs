﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 15f;



    // cached references
    GameSession theGameSeession;
    Ball theBall;


    // Start is called before the first frame update
    void Start(){
        theGameSeession = FindObjectOfType<GameSession>();
        theBall = FindObjectOfType<Ball>();
        
    }

    // Update is called once per frame
    void Update() {
        Vector2 paddlePos = new Vector2(transform.position.x,transform.position.y);
        paddlePos.x = Mathf.Clamp(GetXPos(), minX, maxX);
        transform.position = paddlePos;
    }

    private float GetXPos() {
        if(theGameSeession.IsAutoPlayEnabled()) {
            return theBall.transform.position.x;
        } else {
            return Input.mousePosition.x / Screen.width * screenWidthInUnits;
        }
    }

}
