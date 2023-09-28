using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScenesMove : MonoBehaviour
{

    public void MoveMainGame()
    {
        SceneManager.LoadScene("MainGameScenes");//MainGameScenes move
    }
    public void MoveTitle()
    {
        SceneManager.LoadScene("TitleScenes");//TitleScenes move

    }
    public void MoveExit()
    {
        Application.Quit(); // ���α׷� ����
    }

    public void MoveRestart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainGameScenes");
    }

}
