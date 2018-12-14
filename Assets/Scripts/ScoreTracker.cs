using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTracker : MonoBehaviour {

    public float    score;                  // Starting score
    public int      reductionPerSecond;     // Decrement Score each tick by value
    public float    timer;                  // How much time left

    public int      noiseThresholdLose;     // Lose when exceeding this threshold
    public int      numberOfGifts;          // Number of dropped gifts to win
    public int      scorePerGifts;          // 
    public float    safeTime = 10.0f;          //

    private float   initialTimer;
    private float   finalScore;
    private bool    gameOver    = false;                  
    private bool    won         = false;                  
    private float   giftScore   = 0;                  
    private const string display = "{0} - {1}:{2}";

    public Text scoreText;
    public Text LostText;
    public Text WinText;
    public Text droppedGifts;
    public TMPro.TextMeshPro maxNoise;
    public TMPro.TextMeshPro dangerNoise;
    public GameObject panelWin;
    public GameObject panelLose;
    public GameObject NoiseSensor;
    public GameObject DropZone;
    public GameObject instructions;
    public CharacterController controller;
    public ModifiedOutputVolume volumeSensor;

    private void Start()
    {
        initialTimer = timer;
        maxNoise.text = noiseThresholdLose.ToString();
        dangerNoise.text = (noiseThresholdLose - 10).ToString();
        volumeSensor.MinValue = 0;
        volumeSensor.MaxValue = noiseThresholdLose+10;
        instructions.SetActive(true);
    }

    private void Update()
    {
        if(Input.anyKeyDown){ 
           instructions.SetActive(false);
        }

        if (gameOver)
        {
            float minutes = Mathf.FloorToInt((initialTimer - timer)/60); 
            float seconds = Mathf.RoundToInt((initialTimer - timer)%60);
            if (won)
            {
                panelWin.SetActive(true);
                WinText.text = string.Format("You obtained {0} in {1} min and {2} sec", finalScore, minutes, seconds);
            }
            else
            {
                panelLose.SetActive(true);
                LostText.text = string.Format("You obtained {0} in {1} min and {2} sec", finalScore, minutes, seconds);
            }
            controller.enabled = false;
            scoreText.text = "";
        }
        else
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                timer = 0f;
                gameOver = true;
            }

            checkIfGameOver();
            checkIfWon();

            droppedGifts.text = string.Format("{0} / {1}", getNumberOfDroppedGifts(), numberOfGifts);

            computeScore();
        }
    }

    private void computeScore()
    {
        score -= reductionPerSecond * Time.deltaTime;
        giftScore = getNumberOfDroppedGifts() * scorePerGifts;
        float minutes = Mathf.FloorToInt(timer/60); 
        float seconds = Mathf.RoundToInt(timer%60);
        finalScore = score + giftScore;
        scoreText.text = string.Format(display, Mathf.RoundToInt(finalScore), minutes.ToString("00"), seconds.ToString("00"));
    }

    private void checkIfGameOver()
    {
        if((initialTimer - timer) <= safeTime){
            return;
        }

        if(NoiseSensor.GetComponent<ModifiedOutputVolume>().getValue() >= noiseThresholdLose ||
            timer <= 0f)
        {
            gameOver = true;
        }
    }

    private int getNumberOfDroppedGifts()
    {
        return DropZone.GetComponent<DropZone>().counter;
    }

    private void checkIfWon()
    {
        if(getNumberOfDroppedGifts() >= numberOfGifts)
        {
            gameOver = true;
            won = true;
        }
    }
}
