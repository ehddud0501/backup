using PlatForm.Audio;
using PlatForm.Map;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextStage : MonoBehaviour
{
    [SerializeField] private Door door;
    [SerializeField] private GameObject[] Stage;
    [SerializeField] private AudioMachine playSound;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (door.doorOnOff && collision.gameObject.tag == "Player")
        {
            playSound.PlaySound("NEXTSTAGE");
            Stage[1].SetActive(true);
            door.doorOnOff = false;
            Stage[0].SetActive(false);

        }
    }

}
