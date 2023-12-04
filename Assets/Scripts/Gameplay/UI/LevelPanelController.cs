using System;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelPanelController : MonoBehaviour
{
    
    [SerializeField] private List<Image> stageImages = new List<Image>();
    [SerializeField] private List<TextMeshProUGUI> levelTexts = new List<TextMeshProUGUI>();

    private int stageValue;

    private void Start()
    {
        SetLevelValue();
    }
    
    private void OnEnable()
    {
        EventManager.OnCollectorSuccess += SetStageColor;
    }
    private void OnDisable()
    {
        EventManager.OnCollectorSuccess -= SetStageColor;
    }

    private void SetStageColor()
    {
        stageImages[stageValue].DOColor(new Color(0.9960785f, 0.4196079f, 0.07843138f), 0.5f);
        stageValue++;
    }

    private void SetLevelValue()
    {
        int currentValue = PlayerPrefs.GetInt("Level", 0) + 1;
        levelTexts[0].text = currentValue.ToString();
        levelTexts[1].text = (currentValue + 1).ToString();
    }
}