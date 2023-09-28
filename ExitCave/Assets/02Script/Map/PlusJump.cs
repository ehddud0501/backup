using PlatForm.player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlusJump : MonoBehaviour
{
    [SerializeField] private JumpMoveMent jumpMoveMent;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            jumpMoveMent._plusJump = true;
            gameObject.SetActive(false);
            Invoke("ReSpwan", 3);
        }
        
    }
    private void ReSpwan()
    {
        gameObject.SetActive(true);
    }
}
