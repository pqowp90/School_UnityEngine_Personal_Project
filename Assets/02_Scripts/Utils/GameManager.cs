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
    public PlayerState playerState { get; private set; }

    private void Awake()
    {
        PD = Resources.Load<PlayerData>("SO/" + "PlayerData");
        playerState = PlayerState.Tuto;
    }

    public void SetPlayerState(PlayerState _state)
    {
        playerState = _state;
    }

}
