using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace PlatForm.Score
{
    public class PlusScore : MonoBehaviour
    {

        [SerializeField] private TotalScore total;
        [SerializeField] private int score;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                total.totalScore += score;
                total.scoreInput = true;
                Destroy(gameObject);
            }
        }
    }

}
