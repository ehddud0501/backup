using PlatForm.Audio;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHpUI : MonoBehaviour
{
    [SerializeField] private AudioMachine playSound;
    [SerializeField] private GameObject gameOver;
    [SerializeField] private Slider playerHpder;
    [SerializeField] private Text playerHpText;
    [SerializeField] private Text playerHpMaxText;
    [SerializeField] private PlayerHP _playerHP;

    private void Start()
    {
        gameOver.SetActive(false);
        playerHpText.text = ((int)_playerHP.hp).ToString();
        playerHpMaxText.text = ((int)_playerHP.hpMax).ToString(); 
        
    }

    private void Update()
    {
        if(_playerHP.onChangeHP)
        {
            _playerHP.onChangeHP = false;
            playSound.PlaySound("DAMAGED");
            Debug.Log("점프소리");
            playerHpText.text = ((int)_playerHP.hp).ToString();
            playerHpder.value = _playerHP.hp / _playerHP.hpMax;
        }

        if (_playerHP.onDie)
        {
            playSound.PlaySound("DIE");
            _playerHP.onDie = false;
            gameOver.SetActive(true);
        }

    }


}
