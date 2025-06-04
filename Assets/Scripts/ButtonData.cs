using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonData : MonoBehaviour
{
    Wallet wallet => Wallet.instance;

    [SerializeField] SpriteRenderer player;

    [SerializeField] int price;
    [SerializeField] Text priceText;

    Button button => GetComponent<Button>();

    [SerializeField] Slider gaugeBar;
    bool isclicked = false;

    private void Start()
    {
        priceText.text = price.ToString() + "円";
    }

    private void Update()
    {
        if (wallet.nowCoin >= price && !isclicked)
        {
            // ボタンを押せる
            button.interactable = true;
        }
        else
        {
            // ボタンが押せない
            button.interactable = false;
        }
    }

    // 押した時に呼ばれる関数
    public void OnClick()
    {
        // お金の支払い
        wallet.nowCoin -= price;

        // Playerの召喚
        PlayerSpawn();

        // ボタンを押せないようにする
        isclicked = true;

        // ゲージを出す
        StartCoroutine(SliderUpdate());

    }

    void PlayerSpawn()
    {
        float y = Random.Range(-0.9f, -1.7f);
        SpriteRenderer pl = Instantiate(player, new Vector3(6.4f, y, 0), transform.rotation);
        pl.sortingOrder = (int)(-y * 10);
    }

    IEnumerator SliderUpdate()
    {
        // ゲージを表示
        gaugeBar.value = 0;
        gaugeBar.gameObject.SetActive(true);

        // 時間経過でゲージを進める
        while (gaugeBar.value < gaugeBar.maxValue)
        {
            gaugeBar.value++;
            yield return new WaitForSeconds(0.1f);
        }

        // ゲージを非表示
        gaugeBar.gameObject.SetActive(false);

        // またボタンを押せるようにする
        isclicked = false;
    }
}
