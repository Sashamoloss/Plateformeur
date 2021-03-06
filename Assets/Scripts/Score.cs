﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static Score Instance;
    private int totalScore;
    private TextMeshProUGUI txtMeshPro;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        txtMeshPro = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateScore(int pointsAdded)
    {
        totalScore += pointsAdded;
        txtMeshPro.text = totalScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
