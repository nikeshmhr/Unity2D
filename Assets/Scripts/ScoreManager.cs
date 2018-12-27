using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public static ScoreManager sm;

    // Publics
    public Text scoreText;
    public Transform highScoreParticlePrefab;

    // Privates
    private static int score;
    private int highScore;
    private bool isHighScore = false;
    private Transform mainCharacter;

    private void Awake() {
        if(sm == null) {
            sm = GetComponent<ScoreManager>();
        }

        mainCharacter = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Start() {
        Debug.Log("HIGH SCORE: " + PlayerPrefs.GetInt("highscore"));
        highScore = PlayerPrefs.GetInt("highscore");
        score = 0;
        InvokeRepeating("StartManagingScore", 1f, 1f);
    }

    public void StartManagingScore() {
        // Time based scoring system
        score += 1;

        // Update score
        UpdateScore();

        // Check if high score was beaten
        if(score > highScore) {
            // Only instantiate it once
            if(!isHighScore) {
                Instantiate(highScoreParticlePrefab, mainCharacter.position, Quaternion.identity);
            }
            isHighScore = true;
        }
    }

    public void PlayerDied() {
        CancelInvoke("StartManagingScore");        

        // Overwrite highscore pref if it was beaten
        if (isHighScore) {
            PlayerPrefs.SetInt("highscore", score);
            PlayerPrefs.Save();
        }
    }

    private void UpdateScore() {
        scoreText.text = "Score: " + score;
    }


}
