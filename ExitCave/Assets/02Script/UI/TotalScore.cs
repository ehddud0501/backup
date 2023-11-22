using PlatForm.Audio;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace PlatForm.Score
{
    public class TotalScore : MonoBehaviour
    {
        [SerializeField] private AudioMachine playSound;
        [SerializeField] private Text _totalScoreText;
        public int totalScore;
        public bool scoreInput;

        private void Update()
        {
            if(scoreInput)
            {
                _totalScoreText.text = totalScore.ToString();
                scoreInput = false;
                playSound.PlaySound("INSCORE");
            }
        }


    }

}
