using PlatForm.Map;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlatForm.Score;
using UnityEngine.UI;

public class Finsh : MonoBehaviour
{
    [SerializeField] private GameObject End;
    [SerializeField] private Text finalTotalScoreText;
    [SerializeField] private TotalScore finalTotalScore;

    private int ScoreFinal;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            End.SetActive(true);
            Time.timeScale = 0;
            finalTotalScoreText.text = finalTotalScore.totalScore.ToString();
        }

    }


}
