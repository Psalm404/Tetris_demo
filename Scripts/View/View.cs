using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class View : MonoBehaviour
{
    private RectTransform logoName;
    private RectTransform menuUI;
    private RectTransform gameUI;
    private RectTransform settingUI;
    private Transform map;
    private TextMeshProUGUI score;
    private TextMeshProUGUI highScore;
    private GameObject gameOverUI;
    private TextMeshProUGUI gameOverScore;
    public void UpdateGameUI(int score, int highScore)

    {
        this.score.text = score.ToString();
        this.highScore.text = highScore.ToString();
    }
    private void Awake()
    {
        logoName = transform.Find("Canvas/LOGO") as RectTransform;
        menuUI = transform.Find("Canvas/MENUUI") as RectTransform;
        gameUI = transform.Find("Canvas/GAMEUI") as RectTransform;
        settingUI = transform.Find("Canvas/SettingUI") as RectTransform;
        map = transform.Find("MapDraw/Map");
        score = transform.Find("Canvas/GAMEUI/ScoreNumber").GetComponent<TextMeshProUGUI>();
        gameOverUI = transform.Find("Canvas/OVERUI").gameObject;
        highScore = transform.Find("Canvas/GAMEUI/RecordNumber").GetComponent<TextMeshProUGUI>();
        gameOverScore = transform.Find("Canvas/OVERUI/Score").GetComponent<TextMeshProUGUI>();
        Debug.Log(score);
    }
    public void ShowMenu()
    {
        logoName.gameObject.SetActive(true);
        menuUI.gameObject.SetActive(true);
    }

    public void HideMenu()
    {
        logoName.gameObject.SetActive(false);
        menuUI.gameObject.SetActive(false);
    }

    public void HideGameUI()
    {
        gameUI.gameObject.SetActive(false);
    }

    public void ShowSettingUI()
    {
        settingUI.gameObject.SetActive(true);
    }
    public void HideSettingUI()
    {
        settingUI.gameObject.SetActive(false);
    }

    public void HideGameOverUI() { 
        gameOverUI.gameObject.SetActive(false);
    
    }

    public void ShowGameUI(int score, int highScore = 0)
    {
        this.score.text = score.ToString();
        this.highScore.text = highScore.ToString();
        gameUI.gameObject.SetActive(true);
        Debug.Log(map);
        map.gameObject.SetActive(true);
    }
    public void ShowGameOverUI(int score = 0) { 
        gameOverUI.gameObject.SetActive(true);
        gameOverScore.text = score.ToString();
    }

    public void OnHomeButtonClick() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
