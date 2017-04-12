using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
public class Score : NetworkBehaviour
{
    public const int minScore = 1;
    public int[] scorelist = { 20, 30, 40, 50 };
    public const int minlevel = 1;
    public const int starttime = 30;
    static public Score Singleton;

    [SyncVar]
    public int timeLeft = starttime;

    [SyncVar(hook = "OnChangeScore")]
    public int currentScore = minScore;
    [SyncVar]
    public int currentLevel = minlevel;
    public RectTransform ScoreBar;

    void Awake()
    {
        Debug.Log("score singleton instantiated");
        Singleton = this;
    }
    public void GainScore(int amount)
    {
        if (!isServer)
        {
            Debug.Log("not server");
            return;
        }
        Debug.Log(currentScore);
        currentScore += amount;
        Debug.Log(currentScore);
        Debug.Log("hey");
        if (timeLeft > 0)
        {
            if (currentScore >= scorelist[currentLevel])
            {
                Debug.Log("Pass");
                currentScore = 0;
                GainLevel(currentLevel);

            }
            else
            {

                timeLeft += 1;

            }

        }
        else
        {
            Debug.Log("Fail");
        }


    }
    void OnChangeScore(int score)
    {
        ScoreBar.sizeDelta = new Vector2(currentScore, ScoreBar.sizeDelta.x);
    }
    public void GainLevel(int currentlevel)
    {

    }

}