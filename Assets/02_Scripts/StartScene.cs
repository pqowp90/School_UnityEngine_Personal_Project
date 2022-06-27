using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour
{
    /// <summary>
    /// 게임 시작 버튼 눌렀을 때
    /// </summary>
    public void OnClickStartGame()
    {
        SceneManager.LoadScene(ConstantManager.SCENCE_TUTO);
    }

    /// <summary>
    /// 게임 종료 버튼 눌렀을 때
    /// </summary>
    public void OnClickOutGame()
    {
        Debug.Log("게임종료할께여");
        Application.Quit();
    }
}
