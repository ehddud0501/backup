using PlatForm.Map;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenWall : MonoBehaviour
{
    [SerializeField] private SwitchTriger wallSwitchTriger;
    [SerializeField] private Sprite[] OpenCloseDoor;
    [SerializeField] private SpriteRenderer sprite;
    private BoxCollider2D DoorCollider;


    private void Awake()
    {
        DoorCollider = GetComponent<BoxCollider2D>();
    }


    private void Update()
    {

        if (wallSwitchTriger.SwitchOnOff == true)
        {
            DoorCollider.isTrigger = true;
            sprite.sprite = OpenCloseDoor[1];
        }
        else if (wallSwitchTriger.SwitchOnOff == false)
        {
            DoorCollider.isTrigger = false;
            sprite.sprite = OpenCloseDoor[0];
        }
    }

}
