using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UseItems : MonoBehaviour
{
    private int HP, Weapon;
    
    // Start is called before the first frame update
    void Start()
    {
        HP = Stats.hpPortionNum;
        Weapon = Stats.weaponBonusNum;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void useHP()
    {
        if (HP > 0 && (HPBar.hp + 30000) <= HPBar.maxhp)
        {
            HP--;
            HPBar.hp += 20000;
        }
    }

    public void useWeapon()
    {
        if (Weapon > 0)
        {
            Weapon--;
            SpaceshipWithClicks.FireLimit += 10;
        }
    }
}
