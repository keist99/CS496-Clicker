using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ClicksChanger3 : MonoBehaviour
{
    public Text Clicks, Resources, Money, AutoClickNum, AutoClickSec, AutoConvertON, CurrentMarketingLev, CurrentExchangeRate, CurrentAutoClickPrice;
    public Button Click, Convert, AutoClickPurchase, AutoConvertPurchase, MarketingInvestment;

    public static int ClickNum, ResourceNum, MoneyNum, AutoClick, AutoConvert, CurrentMarketing, CurrentExchange, AutoClickPrice;

    private float TimeLeft = 0.1f, nextTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        //ClickNum = ClicksChanger2.ClickNum;
        ClickNum = 299995; // For debug
        ResourceNum = ClicksChanger2.ResourceNum;
        MoneyNum = ClicksChanger2.MoneyNum;
        AutoClick = ClicksChanger2.AutoClick;
        AutoConvert = ClicksChanger2.AutoConvert;
        AutoClickPrice = 35;
        CurrentMarketing = 0;
        CurrentExchange = 12;
        Clicks.text = "Paperplanes: " + ClickNum.ToString();
        Resources.text = "Paper: " + ResourceNum.ToString();
        Money.text = "Money: " + MoneyNum.ToString();
        AutoClickNum.text = "AutoFolders: " + AutoClick.ToString();
        AutoClickSec.text = "Fold/0.1s: " + (AutoClick * 10).ToString();
        if (AutoConvert == 0) AutoConvertON.text = "AutoConverter: OFF";
        else AutoConvertON.text = "AutoConverter: ON";
        CurrentMarketingLev.text = "Marketing: Lv. " + CurrentMarketing.ToString();
        CurrentExchangeRate.text = "Ratio: $10 : &" + CurrentExchange.ToString();
        CurrentAutoClickPrice.text = "AutoFolder Price: &" + AutoClickPrice.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (ClickNum >= 300000) LoadStage4();
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
            ResourceNum += AutoConvert * CurrentExchange;
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
        if (ResourceNum >= AutoClickPrice)
        {
            ResourceNum -= AutoClickPrice;
            AutoClick++;
            AutoClickNum.text = "AutoFolders: " + AutoClick.ToString();
            AutoClickSec.text = "Fold/0.1s: " + (AutoClick * 10).ToString();
            CurrentAutoClickPrice.text = "AutoFolder Price: &" + AutoClickPrice.ToString();
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

    public void MarketingInvestmentButton()
    {
        int[] MarketingPrice = new int[] { 0, 200, 2000, 10000, 50000 };
        if (CurrentMarketing < 4 && MoneyNum >= MarketingPrice[CurrentMarketing + 1])
        {
            CurrentMarketing++;
            CurrentExchange *= 2;
            MoneyNum -= MarketingPrice[CurrentMarketing];
            CurrentMarketingLev.text = "Marketing: Lv. " + CurrentMarketing.ToString();
            CurrentExchangeRate.text = "Ratio: $10 : &" + CurrentExchange.ToString();
        }
    }

    void LoadStage4()
    {
        SceneManager.LoadScene("Stage4");
    }
}
