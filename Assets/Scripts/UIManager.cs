using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;

    void Start()
    {
        GameManager.Instance.onScoreChanged.AddListener(UpdateUI);
        UpdateUI();
    }

    void UpdateUI()
    {
        scoreText.text = "SCORE: \n" + GameManager.Instance.GetFormattedScore();
        highScoreText.text = "HI-SCORE: \n" + GameManager.Instance.GetFormattedHighScore();
    }
}