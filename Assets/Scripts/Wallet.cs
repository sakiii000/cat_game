using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wallet : MonoBehaviour
{
    public static Wallet instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    [SerializeField] Text coinText;

    public int coinLevel;
    [SerializeField] int[] maxCoin;
    public float nowCoin = 0;

    public int coinSpeed = 6;

    // Start is called before the first frame update
    void Start()
    {
        coinLevel = 0;
        coinText.text = nowCoin.ToString() + "/" + maxCoin[coinLevel].ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isGame && nowCoin <= maxCoin[coinLevel])
        {
            nowCoin += Time.deltaTime * coinSpeed;
            coinText.text = nowCoin.ToString("F0") + "/" + maxCoin[coinLevel].ToString();
        }
    }
}
