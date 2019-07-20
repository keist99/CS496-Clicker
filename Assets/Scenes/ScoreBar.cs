using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBar : MonoBehaviour
{
    public Slider scorebar;
    public Text SliderScore;

    public static int score, barscore, barmaxscore;

    // Start is called before the first frame update
    void Start()
    {
        //score = ClicksChanger4.ClickNum;
        score = 12345; // for debug
        barmaxscore = barscore = 500000;
        scorebar.maxValue = barmaxscore;
        scorebar.value = barscore;
        SliderScore.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        SliderScore.text = score.ToString();
    }
}
