using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpwan : MonoBehaviour
{
    [SerializeField] private GameObject playerSpwan;
    [SerializeField] private GameObject Player;
    private Vector3 playerSpwanPos;

    private void Start()
    {
        playerSpwanPos = playerSpwan.transform.position; 
        Debug.Log("스테이지2 스폰");
        Player.transform.position = playerSpwanPos;
    }


}
