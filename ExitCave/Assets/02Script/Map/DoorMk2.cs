using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMk2 : MonoBehaviour
{
    [SerializeField] private Sprite[] OpenCloseDoor;
    [SerializeField] private bool DoorOn;
    private SpriteRenderer sprite;
    private BoxCollider2D DoorCollider;
    private void Awake()
    {
        DoorCollider = GetComponent<BoxCollider2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Input.GetButtonDown("Interaction"))
        {
            Debug.Log("버튼눌림");
            DoorCollider.isTrigger = true;
            sprite.sprite = OpenCloseDoor[1];

        }
    }

}
