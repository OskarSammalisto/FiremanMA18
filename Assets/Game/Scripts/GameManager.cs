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
    private JumperSpawner jumperSpawner;

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
        jumperSpawner = GetComponent<JumperSpawner>();
    }

    public void JumperCrashed() {

       if(!livesController.RemoveLive())
       {
           Debug.Log("GAME OVER!!!");
           
           jumperSpawner.Stop();
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
