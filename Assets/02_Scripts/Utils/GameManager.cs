using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region SingleTonGameManager
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();
                if (_instance == null)
                {
                    _instance = new GameObject("GameManager").AddComponent<GameManager>();
                }
            }
            return _instance;
        }
    }
    #endregion

    private PlayerData PD;

    public float playerLife = 10f;

    public PlayerData playerData { get { return PD; } }
    public Tutorial_State tutoState;
    public PlayState state;
    public CurrentLevel currentLevel;
    public int itemCnt = 0;
    public Transform playerTrn = null;
    private void Awake()
    {
        playerTrn = GameObject.FindWithTag(ConstantManager.TAG_PLAYER).GetComponent<Transform>();

        PD = Resources.Load<PlayerData>("SO/" + "PlayerData");
    }

    private void OnEnable()
    {
        // reset Setting
        tutoState = Tutorial_State.isPlay;
    }

    public void SetPlayerValues()
    {
        playerData.speed = 13;
        playerData.runspeed = 15;
        playerData.jumpForce = 3;
    }

    public void SettingPlayerLife(float _value)
    {
        playerLife -= _value;

        if (playerLife <= 0)
        {
            Debug.Log("Player Die");
            SceneManager.LoadScene(ConstantManager.SCENCE_START);
        }

    }

}
