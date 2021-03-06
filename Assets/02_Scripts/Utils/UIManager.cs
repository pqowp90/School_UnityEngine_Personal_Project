using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    #region SingleTonGameManager
    private static UIManager _instance;
    public static UIManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<UIManager>();
                if (_instance == null)
                {
                    _instance = new GameObject("UIManager").AddComponent<UIManager>();
                }
            }
            return _instance;
        }
    }
    #endregion
    [Header("Objects")]
    [SerializeField] private GameObject SettingChangObj = null;

    public Image hpBar = null;
    public Image level_gaze = null;


    private bool isSetting = false;
    private void Update()
    {
        InputKeyCheck();
    }

    private void InputKeyCheck()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isSetting = !isSetting;
            if (isSetting)
            {
                GameManager.Instance.state = PlayState.isSetting;
                Time.timeScale = 0f;
                StartSetting();
            }
            else
            {
                GameManager.Instance.state = PlayState.isPlaying;
                Time.timeScale = 1f;
                EndSetting();
            }
        }
    }

    /// <summary>
    /// ?޴??? ???ư??? ?????? ??
    /// </summary>
    public void OnClickGoToMenu()
    {
        Debug.Log("?? ?̵??Ҳ???\n");
        SceneManager.LoadScene(ConstantManager.SCENCE_START);
    }

    /// <summary>
    /// ???? ?ݱ? ?????? ??
    /// </summary>
    public void OnClickSulChangOut()
    {
        SettingChangObj.SetActive(false);
    }

    private void EndSetting()
    {
        SettingChangObj.transform.DOScaleY(0f, 0.15f).SetUpdate(true);
        //SettingChangObj.SetActive(false);
    }

    private void StartSetting()
    {
        SettingChangObj.SetActive(true);
        SettingChangObj.transform.DOScaleY(1f, 0.15f).SetUpdate(true);
    }

    public void UpdateUI()
    {
        hpBar.fillAmount = GameManager.Instance.playerLife / 10f;
        level_gaze.fillAmount = GameManager.Instance.itemCnt / 10f;

    }
}
