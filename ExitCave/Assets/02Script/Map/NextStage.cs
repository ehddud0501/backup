using PlatForm.Map;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextStage : MonoBehaviour
{
    [SerializeField] private Door door;
    [SerializeField] private GameObject[] Stage;
    private int stageNum = 0;


       
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (door.doorOnOff && collision.gameObject.tag == "Player")
        {
            int a = stageNum;
            stageNum += 1;
            Stage[stageNum].SetActive(true);
            door.doorOnOff = false;
            Stage[a].SetActive(false);

        }
    }

}
