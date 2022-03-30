using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private int score = 0;

    [SerializeField]
    private Text LoseText;
    [SerializeField]
    private Text ScoreText;

    public void PointScored()
    {
        score++;
        ScoreText.text = $"Score: {score}";
    }

    public void LoseScreen()
    {
        LoseText.gameObject.SetActive(true);
    }
}
