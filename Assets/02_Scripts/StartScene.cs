using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour
{
    /// <summary>
    /// ���� ���� ��ư ������ ��
    /// </summary>
    public void OnClickStartGame()
    {
        SceneManager.LoadScene(ConstantManager.SCENCE_TUTO);
    }

    /// <summary>
    /// ���� ���� ��ư ������ ��
    /// </summary>
    public void OnClickOutGame()
    {
        Debug.Log("���������Ҳ���");
        Application.Quit();
    }
}
