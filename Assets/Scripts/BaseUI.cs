using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseUI : MonoBehaviour
{
    [SerializeField] Text hpText;
    [SerializeField] HitPoint hitPoint;

    int maxHP;
    int nowHP;

    // Start is called before the first frame update
    void Start()
    {
        maxHP = hitPoint.hp;
        nowHP = maxHP;
        UpdateUI();
    }

    public void UpdateUI()
    {
        nowHP = hitPoint.hp;
        if (nowHP <= 0)
        {
            nowHP = 0;
        }
        hpText.text = nowHP.ToString() + "/" + maxHP.ToString();
    }
}
