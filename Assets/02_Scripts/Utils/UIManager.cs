using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] private GameObject SettingChangObj = null;

    private void Update()
    {
        InputKeyCheck();
    }

    private void InputKeyCheck()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("³ª°¬¼­¿ë");
        }
    }

    private void OutGame()
    {

    }

}
