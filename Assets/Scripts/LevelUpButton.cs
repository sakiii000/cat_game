using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpButton : MonoBehaviour
{
    Wallet wallet => Wallet.instance;

    [SerializeField] Text levelText;
    [SerializeField] Text priceText;

    int level = 1;
    [SerializeField] int[] price;

    Button button => GetComponent<Button>();

    bool isMax = false;

    void Start()
    {
        levelText.text = "Level " + level.ToString();
        priceText.text = price[level - 1].ToString() + "円";
    }

    void Update()
    {
        if (!isMax)
        {
            if (wallet.nowCoin >= price[level - 1])
            {
                // ボタンを押せる
                button.interactable = true;
            }
            else
            {
                // ボタンを押せない
                button.interactable = false;
            }
        }
    }

    public void OnClick()
    {
        if (level >= price.Length)
        {
            // MAXになるときの処理
            isMax = true;
            priceText.text = "MAX";
            levelText.gameObject.SetActive(false);
            button.interactable = true;
            button.enabled = false;
        }
        else
        {
            // 必要な金額の消費
            wallet.nowCoin -= price[level - 1];

            // レベルを上げる
            level++;

            // コインのスピードを上げる
            wallet.coinSpeed += 6;

            // textの表示を変更
            levelText.text = "Level " + level.ToString();
            priceText.text = price[level - 1].ToString() + "円";

            // 財布のmaxCoinを更新
            wallet.coinLevel++;
        }
    }
}
