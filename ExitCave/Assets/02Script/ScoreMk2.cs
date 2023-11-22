using PlatForm.Score;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreMk2 : MonoBehaviour
{
    [SerializeField] private TotalScore total;
        
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "ScorePoint")
        {
            string point = collision.gameObject.name;

            switch(point)
            {
                case "100":
                    total.totalScore += 100;
                    break;
                case "500":
                    total.totalScore += 500;
                    break;
                case "1000":
                    total.totalScore += 1000;
                    break;
                case "10000":
                    total.totalScore += 10000;
                    break;
            }


        }
    }
}
