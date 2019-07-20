using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HPBar : MonoBehaviour
{
    public Slider hpbar;
    public Text SliderHP;

    public static int hp, maxhp;

    // Start is called before the first frame update
    void Start()
    {
        maxhp = hp = 500000;
        hpbar.maxValue = maxhp;
        hpbar.value = hp;
        SliderHP.text = "100%";
    }

    // Update is called once per frame
    void Update()
    {
        hpbar.value = hp;
        SliderHP.text = ((int)(100.0f * hp / maxhp)).ToString() + "%";
        if (hp <= 0) SceneManager.LoadScene("GameOver");
    }
}
