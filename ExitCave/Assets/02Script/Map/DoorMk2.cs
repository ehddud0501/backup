using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMk2 : MonoBehaviour
{
    [SerializeField] private Sprite[] OpenCloseDoor;
    private bool openAndOff;
    private SpriteRenderer sprite;
    private BoxCollider2D DoorCollider;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if(Input.GetButtonDown("Interaction"))
            {
                if (openAndOff)
                {
                    DoorCollider.isTrigger = true;
                    sprite.sprite = OpenCloseDoor[1];
                    openAndOff = false;
                }
                else if (openAndOff == false)
                {
                    DoorCollider.isTrigger = false;
                    sprite.sprite = OpenCloseDoor[0];
                    openAndOff = true;
                }
            }
        }
    }
}
