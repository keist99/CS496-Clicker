using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ClicksChanger1 : MonoBehaviour
{
    public Text Clicks, Resources, Money;
    public Button Click, Convert;

    public static int ClickNum, ResourceNum, MoneyNum;

    // Start is called before the first frame update
    void Start()
    {
        //ClickNum = 0;
        ClickNum = 85; // For debug
        ResourceNum = 10000;
        MoneyNum = 10;
        Clicks.text = "Paperplanes: " + ClickNum.ToString();
        Resources.text = "Paper: " + ResourceNum.ToString();
        Money.text = "Money: " + MoneyNum.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Clicks.text = "Paperplanes: " + ClickNum.ToString();
        Resources.text = "Paper: " + ResourceNum.ToString();
        Money.text = "Money: " + MoneyNum.ToString();
    }

    public void ClickButton()
    {
        if (ResourceNum > 0)
        {
            ClickNum++;
            MoneyNum++;
            ResourceNum--;
        }
        if (ClickNum >= 100) LoadStage2();
    }

    public void ConvertButton()
    {
        if (MoneyNum > 0)
        {
            MoneyNum--;
            ResourceNum++;
        }
    }

    void LoadStage2()
    {
        SceneManager.LoadScene("Stage2");
    }
}
