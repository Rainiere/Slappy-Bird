using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
 using Random = UnityEngine.Random;

public class Manager : MonoBehaviour
{
    [SerializeField] private Obstacles Obstacle;
    [SerializeField] private float Timer;       //Adjustable timer between Obstacle spawns
                     private float TimerToUse = 0.5f;  //Timer variable to use in the code to spawn obstacles and assign back to the Timer value when < 

    [SerializeField] private int MaxObstacles;
    [SerializeField] private GameObject PlayerObject;

    private int Counter;

    private void Init(){
        if(Counter == MaxObstacles){
            return;
        }
        Instantiate(Obstacle, new Vector2(10, Random.Range( -3,  4)), Quaternion.identity);
        Counter++;
    }


[SerializeField] private string[] Scores ={"Score1", "Score2","Score3", "Score4", "Score5"};

[SerializeField] private GameObject HighscorePanel;
[SerializeField] private TMP_Text HighestScore;
[SerializeField] private TMP_Text SecondHighestScore;
[SerializeField] private TMP_Text ThirdHighestScore;
[SerializeField] private TMP_Text FourthHighestScore;
[SerializeField] private TMP_Text FifthHighestScore;

    public void Highscore( int Score){
        SortArray();
        if(Score > PlayerPrefs.GetInt(Scores[0])){
            PlayerPrefs.SetInt(Scores[0], Score);
            for(int i = 1; i < Scores.Length; i++){
                if(PlayerPrefs.GetInt(Scores[i-1]) > PlayerPrefs.GetInt(Scores[i])){
                    (Scores[i-1], Scores[i]) = (Scores[i], Scores[i-1]);
                }
            }
        }
        HighscorePanel.SetActive(true);
        HighestScore.text = PlayerPrefs.GetInt(Scores[4]).ToString();
        SecondHighestScore.text = PlayerPrefs.GetInt(Scores[3]).ToString();
        ThirdHighestScore.text = PlayerPrefs.GetInt(Scores[2]).ToString();
        FourthHighestScore.text = PlayerPrefs.GetInt(Scores[1]).ToString();
        FifthHighestScore.text = PlayerPrefs.GetInt(Scores[0]).ToString();
    }

    private void SortArray(){
    int[] SortedScores = new int[Scores.Length];

    for(int i = 0; i < Scores.Length; i++){ SortedScores[i] = PlayerPrefs.GetInt(Scores[i]); }

     Array.Sort(SortedScores, Scores);
    }

    public void RestartGame(){
        Time.timeScale = 1;
        SceneManager.LoadScene (sceneName: "TheGame");
    }
    void Update()
    {
    TimerToUse -= Time.deltaTime;
        if(TimerToUse <= 0){
            Init();
            TimerToUse = Obstacle.ResetSpeed / MaxObstacles;
        }
        if(Input.GetKeyDown(KeyCode.Escape)){
            Application.Quit();
        }
    }
    }