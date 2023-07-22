using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents Instance;

    public delegate void OnEnteredLeafDelegate();

    public delegate void OnScoreChangedDelegate(int score);

    public delegate void OnGameEndedDelegate();


    public OnGameEndedDelegate OnGameEnded;
    public OnEnteredLeafDelegate OnEnteredLeaf;

    public OnScoreChangedDelegate OnScoreChanged;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

    }



}

