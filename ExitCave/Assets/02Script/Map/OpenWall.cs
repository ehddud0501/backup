using PlatForm.Map;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenWall : MonoBehaviour
{
    [SerializeField] private SwitchTriger wallSwitchTriger;
    private Vector3 WallPos;

    private void Start()
    {
        WallPos = transform.position;
    }


    private void Update()
    {
        if (wallSwitchTriger.SwitchOnOff == true)
        {
            transform.position = new Vector3(WallPos.x, WallPos.y + 2.5f, WallPos.z);
        }
        else if (wallSwitchTriger.SwitchOnOff == false)
        {
            transform.position = WallPos;
        }
    }

}
