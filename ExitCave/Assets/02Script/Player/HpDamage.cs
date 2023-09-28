using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlatForm.player
{
    public class HpDamage : MonoBehaviour
    {
        [SerializeField] private GameObject playerLayer;
        [SerializeField] private Player player;
        [SerializeField] private PlayerHP _playerHP;
        [SerializeField] private float _damage;
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                OnDamage();
                Invoke("OffDamage", 3);
            }
        }
        private void OnDamage()
        {
            if(_playerHP.hp > 0)
            _playerHP.hp -= _damage;
            
            if (_playerHP.hp == 0 || _playerHP.hp < 0)
            {
                _playerHP.hp = 0;
                OnDie();
            }               
            
            _playerHP.onChangeHP = true;
            playerLayer.layer = 11;
            player.spriteRenderer.color = new Color(1, 1, 1, 0.4f);            
        }
        private void OffDamage()
        {
            playerLayer.layer = 10;
            player.spriteRenderer.color = new Color(1, 1, 1, 1);
        }
        private void OnDie()
        {
            Destroy(playerLayer);
            Time.timeScale = 0;
            _playerHP.onDie = true;
        }

    }

}

