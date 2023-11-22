using PlatForm.Map;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlatForm.Map
{
    public class Door : MonoBehaviour
    {
        [SerializeField] private Sprite[] OpenCloseDoor;
        [SerializeField] private SpriteRenderer sprite;
        [SerializeField] private SwitchTriger[] switchTriger;
        [SerializeField] private bool OneOrMultipleSwitch;
        public bool doorOnOff;
        private void Update()
        {
            if(OneOrMultipleSwitch)
            {
                for(int i = 0; i < switchTriger.Length; i++)
                {
                    if (switchTriger[i].SwitchOnOff == true)
                        doorOnOff = true;
                    else if (switchTriger[i].SwitchOnOff == false)
                    {
                        sprite.sprite = OpenCloseDoor[0];
                        doorOnOff = false;
                        break;
                    }
                }
                if(doorOnOff)
                    sprite.sprite = OpenCloseDoor[1];
            }
            else if(OneOrMultipleSwitch == false)
            {
                    if (switchTriger[0].SwitchOnOff == true)
                    {
                        sprite.sprite = OpenCloseDoor[1];
                        doorOnOff = true;
                    }
                    else if (switchTriger[0].SwitchOnOff == false)
                    {
                        sprite.sprite = OpenCloseDoor[0];
                        doorOnOff = false;
                    }
            }
        }

    }

}