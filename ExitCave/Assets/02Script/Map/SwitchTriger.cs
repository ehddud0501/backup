using PlatForm.Audio;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace PlatForm.Map
{
    public class SwitchTriger : MonoBehaviour
    {
        [SerializeField] private AudioMachine playSound;
        [SerializeField] private SpriteRenderer sprite;
        [SerializeField] private SpriteRenderer iconsprite;
        [SerializeField] private Sprite offSwitch;
        [SerializeField] private Sprite onSwitch;
        [SerializeField] private Sprite offSwitchicon;
        [SerializeField] private Sprite onSwitchicon;
        public bool playerdetect;
        public bool SwitchOnOff;
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Player")            
                playerdetect = true;          
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Player")
                playerdetect = false;
        }
        private void Update()
        {
            if (playerdetect)
            {
                if (Input.GetButtonDown("Interaction") && SwitchOnOff)
                {
                    playSound.PlaySound("INTERACTION");
                    sprite.sprite = offSwitch;
                    iconsprite.sprite = offSwitchicon;
                    SwitchOnOff = false;
                }
                else if (Input.GetButtonDown("Interaction") && SwitchOnOff == false)
                {
                    playSound.PlaySound("INTERACTION");
                    iconsprite.sprite = onSwitchicon;
                    sprite.sprite = onSwitch;
                    SwitchOnOff = true;
                }
            }
        }
    }
}

