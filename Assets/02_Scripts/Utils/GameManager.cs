using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public PlayerData playerData { get { return PD; } }
    public Tutorial_State tutoState;

    private void Awake()
    {
        PD = Resources.Load<PlayerData>("SO/" + "PlayerData");
        SetPlayerValues();
    }   

    private void OnEnable()
    {
        // reset Setting
        tutoState = Tutorial_State.isPlay;
        Debug.Log(tutoState);
    }

    private void SetPlayerValues()
    {
        playerData.speed = 13;
        playerData.runspeed = 15;
        playerData.jumpForce = 3;
    }

}
