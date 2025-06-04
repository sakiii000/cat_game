using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// ゲーム全体を管理する
public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] GameObject clearPanel;
    [SerializeField] GameObject gameOverPanel;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public bool isGame = false;

    // Start is called before the first frame update
    void Start()
    {
        isGame = true;
        clearPanel.SetActive(false);
        gameOverPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameClear()
    {
        isGame = false;
        clearPanel.SetActive(true);
    }

    public void GameOver()
    {
        isGame = false;
        gameOverPanel.SetActive(true);
    }

    public void ReStart()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
