using PlatForm.player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    public float hp;
    private float hpMin = 0;
    public float hpMax;
    public bool onChangeHP;
    public bool onDie;


    private void Start()
    {
        hp = hpMax;
    }

}
