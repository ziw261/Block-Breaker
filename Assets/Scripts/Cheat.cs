using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cheat : MonoBehaviour {
    [SerializeField] GameObject gobj1;


    public void CheatTrigger() {
        gobj1.GetComponent<BoxCollider2D>().isTrigger = false;
    }
   
}
