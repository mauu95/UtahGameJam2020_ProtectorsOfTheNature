using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponsManager : MonoBehaviour
{
    public Weapon[] weapons;

    public Sprite[] appleshooterSprites;

    public Sprite GetAppleShooterSpriteLevel(int level)
    {
        if (level > 2)
            level = 2;
        return appleshooterSprites[level];
    }
}
