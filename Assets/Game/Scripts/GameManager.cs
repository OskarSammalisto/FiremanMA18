using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    private string sceneMain = "Main";
    
    public int startLives = 3;
    private int points = 0;

    public LivesController livesController;
    public TextMeshPro scoreText;
    private JumperSpawner jumperSpawner;
    public GameObject gameOverSign;
    public GameObject input;

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
        gameOverSign.SetActive(false);
    }

    public int Points() {
        return points;
    }

    public void JumperCrashed() {

       if(!livesController.RemoveLive())
       {
           GameOver();
       } 
        
        
    }

    public void JumperSaved() {
        points++;
        UpdateScore();
    }

    void UpdateScore() {
        scoreText.text = points.ToString();
    }

    private void GameOver() {
        gameOverSign.SetActive(true);
        jumperSpawner.Stop();
        input.SetActive(false);
    }

    public void RestartGame() {
        //restart scene
        SceneManager.LoadScene(sceneMain);
    }
    
}
