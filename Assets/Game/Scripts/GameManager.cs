using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour {
    public int startLives = 3;
    private int points = 0;

    public LivesController livesController;
    public TextMeshPro scoreText;

    private void OnEnable() {
        JumperController.OnJumperCrash += JumperCrashed;
        JumperController.OnJumperSave += JumperSaved;
    }

    private void OnDisable() {
        JumperController.OnJumperCrash -= JumperCrashed;
        JumperController.OnJumperSave -= JumperSaved;
    }

    private void Start() {
        UpdateScore();
        livesController.InitializeLives(startLives);
    }

    public void JumperCrashed() {

       if(!livesController.RemoveLive())
       {
           Debug.Log("GAME OVER!!!");
       } 
        
        
    }

    public void JumperSaved() {
        points++;
        UpdateScore();
    }

    void UpdateScore() {
        scoreText.text = points.ToString();
    }
    
}
