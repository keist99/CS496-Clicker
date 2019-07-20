using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Stats : MonoBehaviour
{
    public Text clickLeft, stats;

    public static int hpPortionNum, weaponBonusNum, clicks;

    // Start is called before the first frame update
    void Start()
    {
        Screen.orientation = ScreenOrientation.Landscape;

        hpPortionNum = 0;
        weaponBonusNum = 0;
        //clicks = ClicksChanger4.ClickNum - 150000;
        clicks = 150000;
    }

    // Update is called once per frame
    void Update()
    {
        clickLeft.text = "Clicks Left: " + clicks.ToString();
        stats.text = "Weapon Bonus: " + (weaponBonusNum * 10).ToString() + ", HP Bonus: " + (hpPortionNum * 30000).ToString();
    }

    public void hpPortionPurchase()
    {
        if (clicks >= 10000)
        {
            clicks -= 10000;
            hpPortionNum++;
        }
    }

    public void weaponPurchase()
    {
        if (clicks >= 10000)
        {
            clicks -= 10000;
            weaponBonusNum++;
        }
    }

    public void LoadSpace()
    {
        SceneManager.LoadScene("Spaceship1");
    }
}
