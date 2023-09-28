using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace PlatForm.Score
{
    public class TotalScore : MonoBehaviour
    {
        [SerializeField] private Text _totalScoreText;
        private PlusScore plusScore;
        public int totalScore;
        public bool scoreInput;

        private void Update()
        {
            if(scoreInput)
            {
                _totalScoreText.text = totalScore.ToString();
                scoreInput = false;
            }
        }


    }

}
