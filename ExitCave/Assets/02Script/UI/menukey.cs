using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menukey : MonoBehaviour
{
    [SerializeField] private GameObject MenuUI;
    private bool menuopen;

    private void Menu()
    {
        if (Input.GetButtonDown("Cancel")) 
        {
            if (menuopen == false)
            {
                Time.timeScale = 0;
                MenuUI.SetActive(true);
                menuopen = true;
            }
            else if(menuopen)
            {
                Time.timeScale = 1;
                MenuUI.SetActive(false);
                menuopen = false;
            }
        }
    }

    private void Update()
    {
        Menu();
    }
}
