using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChartController : MonoBehaviour
{
    public static ChartController instance { get; private set; }
    public GameObject chart;
    public GameObject nameHorse;
    public TextMeshProUGUI timer;
    public TextMeshProUGUI score;
    public List<HorseController> horseControllers;
    public List<TextMeshProUGUI> rankHorse;

    private bool pressed;
    private int microSeconds;
    private int seconds;
    private int minutes;
    private int scores;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Start()
    {
        scores = 0;
    }

    private void FixedUpdate()
    {
        Meters();
        Timer();
    }
    private void LateUpdate()
    {
        Ranking();
    }
    public void ToggleChart()
    {
        pressed = !pressed;

        if (chart != null)
        {
            chart.SetActive(pressed);
        }

        if (nameHorse != null)
        {
            nameHorse.SetActive(pressed);
        }
    }

    private void Meters()
    {
        scores++;
        if (score != null)
        {
            score.text = scores.ToString();
        }
    }

    private void Timer()
    {
        microSeconds++;
        if (microSeconds == 60)
        {
            microSeconds = 0;
            seconds++;
        }

        if (seconds == 60)
        {
            seconds = 0;
            minutes++;
        }

        if (timer != null)
        {
            timer.text = string.Format("{0:D2}:{1:D2}", minutes, seconds);
        }
    }

    public int GetMeter()
    {
        return scores;
    }

    private void Ranking()
    {
        for (int i = 0; i < horseControllers.Count - 1; i++)
        {
            for (int j = 0; j < horseControllers.Count - i - 1; j++)
            {
                if (horseControllers[j].transform.position.z < horseControllers[j + 1].transform.position.z)
                {
                    HorseController temp = horseControllers[j];
                    horseControllers[j] = horseControllers[j + 1];
                    horseControllers[j + 1] = temp;
                }
            }
        } 

        for (int i = 0; i < horseControllers.Count; i++)
        {
            if (i < rankHorse.Count && rankHorse[i] != null)
            {
                rankHorse[i].text = i + " : " + horseControllers[i].name;
            }
        }
    }
}
