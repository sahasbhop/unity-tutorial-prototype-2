using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandleHungerBar : MonoBehaviour
{
    public Slider slider;
    public int max;

    private GameManager _gameManager;
    
    private void Start()
    {
        slider.maxValue = max;
        slider.fillRect.gameObject.SetActive(false);
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void Feed()
    {
        if (slider.value < max)
        {
            slider.value += 1;
            slider.fillRect.gameObject.SetActive(true);
        }
        if (slider.value >= max)
        {
            Destroy(gameObject, 0.05f);
            _gameManager.IncreaseScore();
        }
    }
}
