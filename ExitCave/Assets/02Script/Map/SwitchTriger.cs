using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace PlatForm.Map
{
    public class SwitchTriger : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer sprite;
        [SerializeField] private Sprite offSwitch;
        [SerializeField] private Sprite onSwitch;
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
                if (Input.GetButtonDown("Fire1") && SwitchOnOff)
                {
                    Debug.Log("확인off");
                    sprite.sprite = offSwitch;
                    SwitchOnOff = false;
                }
                else if (Input.GetButtonDown("Fire1") && SwitchOnOff == false)
                {
                    Debug.Log("확인on");
                    sprite.sprite = onSwitch;
                    SwitchOnOff = true;
                }
            }
        }
    }
}

