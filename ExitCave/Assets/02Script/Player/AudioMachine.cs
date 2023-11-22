using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlatForm.Audio
{
    public class AudioMachine : MonoBehaviour
    {
        [SerializeField] private AudioClip audioDamaged;
        [SerializeField] private AudioClip audioDie;
        [SerializeField] private AudioClip audioFinish;
        [SerializeField] private AudioClip audioInScore;
        [SerializeField] private AudioClip audioInteraction;
        [SerializeField] private AudioClip audioNextStage;
        [SerializeField] private AudioClip audioJump;
        private AudioSource audioSource;

        private void Awake()
        {
            audioSource = GetComponent<AudioSource>();
        }

        public void PlaySound(string action)
        {
            audioSource.Stop();
            switch (action)
            {
                case "JUMP":
                    audioSource.clip = audioJump;
                    break;
                case "DIE":
                    audioSource.clip = audioDie;
                    break;
                case "DAMAGED":
                    audioSource.clip = audioDamaged;
                    break;
                case "FINISH":
                    audioSource.clip = audioFinish;
                    break;
                case "INSCORE":
                    audioSource.clip = audioInScore;
                    break;
                case "INTERACTION":
                    audioSource.clip = audioInteraction;
                    break;
                case "NEXTSTAGE":
                    audioSource.clip = audioNextStage;
                    break;
            }


            audioSource.Play();
        }
    }
}

