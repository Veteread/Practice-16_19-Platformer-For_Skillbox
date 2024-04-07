using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Vars : MonoBehaviour
{
    public int sumEnemy = 0;
    public int sumtoken = 0;
    public Text SumtokenText;
    public Text SumscoreText;
    public Text HighscoreText;
    public Text SumEnemyText;
    private GameObject[] tokens;
    private GameObject[] enemies;
    public int score;
    public int _SumScore;
    public int _HighScore;

    private bool finishLvl = true;

    void Start()
    {
        tokens = GameObject.FindGameObjectsWithTag("Token");
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        PlayerPrefs.GetInt("LvlScore");
        HighscoreText.text = PlayerPrefs.GetInt("LvlScore") + "";
    }

    public void Sumtoken(int token)
    {
        sumtoken += token;
        score = token * 5;
        SumScore();
        SumtokenText.text = sumtoken + " из " + tokens.Length;
    }
    public void SumEnemy(int enemy)
    {
        sumEnemy += enemy;
        score = enemy * 10;
        SumScore();
        SumEnemyText.text = sumEnemy + " из " + enemies.Length;
    }
    public void SumScore()
    {
        _SumScore += score;
        PlayerPrefs.SetInt("scor", _SumScore);
        SumscoreText.text = PlayerPrefs.GetInt("scor") + "";
        HighscoreText.text = PlayerPrefs.GetInt("LvlScore") + PlayerPrefs.GetInt("scor") + "";


        //if (PlayerPrefs.GetInt("Highscor") <= PlayerPrefs.GetInt("scor"))
        //{
        //    _HighScore = _SumScore + _HighScore;
        //    PlayerPrefs.SetInt("Highscor", _HighScore);
        //}
    }
    public void ResetHighScore()
    {
        PlayerPrefs.SetInt("scor", 0);
        PlayerPrefs.SetInt("LvlScore", 0);
        PlayerPrefs.SetInt("HighScor", 0);
    }
    public void SaveScoreFormlastLvl()
    {
        _SumScore = PlayerPrefs.GetInt("LvlScore") + _SumScore;
        PlayerPrefs.SetInt("LvlScore", _SumScore);
        HighscoreText.text = PlayerPrefs.GetInt("LvlScore") + "";
    }
    public void LoadScoreFormlastLvl()
    {
        if (finishLvl == true)
        {
            _HighScore = PlayerPrefs.GetInt("LvlScore") + _SumScore;
            HighscoreText.text = PlayerPrefs.GetInt("LvlScore") + "";
            Debug.Log(_HighScore);
            finishLvl = false;
        }
    }
}
