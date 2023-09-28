using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlatForm.player
{
    public class HpHeal : MonoBehaviour
    {
        [SerializeField] private PlayerHP playerHP;
        [SerializeField] private float heal;
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                if (playerHP.hp < 400)
                {
                    playerHP.onChangeHP = true;
                    playerHP.hp += heal;
                }
                else if (playerHP.hp >= 400)
                {
                    playerHP.onChangeHP = true;
                    playerHP.hp = 500;
                }           
                Destroy(gameObject);
            }
        }

    }

}

