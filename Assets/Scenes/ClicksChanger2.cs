using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ClicksChanger2 : MonoBehaviour
{
    public Text Clicks, Resources, Money, AutoClickNum, AutoClickSec, AutoConvertON;
    public Button Click, Convert, AutoClickPurchase, AutoConvertPurchase;

    public static int ClickNum, ResourceNum, MoneyNum, AutoClick, AutoConvert;

    private float TimeLeft = 0.1f, nextTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        //ClickNum = ClicksChanger1.ClickNum;
        ClickNum = 17995; // For debug
        ResourceNum = ClicksChanger1.ResourceNum;
        MoneyNum = ClicksChanger1.MoneyNum;
        AutoClick = 0;
        AutoConvert = 0;
        Clicks.text = "Paperplanes: " + ClickNum.ToString();
        Resources.text = "Paper: " + ResourceNum.ToString();
        Money.text = "Money: " + MoneyNum.ToString();
        AutoClickNum.text = "AutoFolders: " + AutoClick.ToString();
        AutoClickSec.text = "Fold/0.1s: " + (AutoClick * 10).ToString();
        AutoConvertON.text = "AutoConverter: OFF";
    }

    // Update is called once per frame
    void Update()
    {
        if (ClickNum >= 18000) LoadStage3();
        Clicks.text = "Paperplanes: " + ClickNum.ToString();
        Resources.text = "Paper: " + ResourceNum.ToString();
        Money.text = "Money: " + MoneyNum.ToString();
        if (Time.time > nextTime)
        {
            nextTime = Time.time + TimeLeft;
            AutoClickActivate();
            AutoConvertActivate();
        }
    }

    void AutoClickActivate()
    {
        if (ResourceNum >= AutoClick * 10)
        {
            ResourceNum -= AutoClick * 10;
            MoneyNum += AutoClick * 10;
            ClickNum += AutoClick * 10;
        }
    }

    void AutoConvertActivate()
    {
        if (MoneyNum >= AutoConvert * 10)
        {
            MoneyNum -= AutoConvert * 10;
            ResourceNum += AutoConvert * 12;
        }
    }

    public void ClickButton()
    {
        if (ResourceNum > 0)
        {
            ClickNum++;
            MoneyNum++;
            ResourceNum--;
        }
        if (ResourceNum == 0 && AutoConvert == 1)
        {
            if (MoneyNum >= 10)
            {
                MoneyNum -= 10;
                ResourceNum += 10;
            }
        }
    }

    public void ConvertButton()
    {
        if (MoneyNum > 0)
        {
            MoneyNum--;
            ResourceNum++;
        }
    }

    public void AutoClickPurchaseButton()
    {
        if (ResourceNum >= 35)
        {
            ResourceNum -= 35;
            AutoClick++;
            AutoClickNum.text = "AutoFolders: " + AutoClick.ToString();
            AutoClickSec.text = "Fold/0.1s: " + (AutoClick * 10).ToString();
        }
    }

    public void AutoConvertPurchaseButton()
    {
        if (ResourceNum >= 20 && AutoConvert == 0)
        {
            ResourceNum -= 20;
            AutoConvert++;
            AutoConvertON.text = "AutoConverter: ON";
        }
    }

    void LoadStage3()
    {
        SceneManager.LoadScene("Stage3");
    }
}
