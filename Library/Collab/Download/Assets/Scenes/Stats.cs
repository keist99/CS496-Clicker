using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Stats : MonoBehaviour
{
    public Text clickLeft, stats;

    static int hpPortionNum, weaponBonusNum, clicks;
    
    // Start is called before the first frame update
    void Start()
    {
        Screen.orientation = ScreenOrientation.Landscape;

        hpPortionNum = 0;
        weaponBonusNum = 0;
        //clicks = ClicksChanger4.ClickNum;
        clicks = 150000;
    }

    // Update is called once per frame
    void Update()
    {
        clickLeft.text = "Clicks Left: " + clicks.ToString();
        stats.text = "Current Weapon: " + (50 + weaponBonusNum).ToString() + ", Current HP: " + (500000 + hpPortionNum * 10000);
    }

    public void hpPortionPurchase()
    {
        if (clicks >= 10000)
        {
            clicks -= 10000;
            weaponBonusNum += 10;
        }
    }

    public void weaponPurchase()
    {
        if (clicks >= 10000)
        {
            clicks -= 10000;
            hpPortionNum++;
        }
    }

    public void LoadSpace()
    {
        SceneManager.LoadScene("Spaceship");
    }
}
