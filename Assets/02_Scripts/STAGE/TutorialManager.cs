using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class TutorialManager : MonoBehaviour
{
    public Tutorial_State state { get; private set; }
    private PlayerData playerData { get; set; }

    [Header("------- Player -------")]
    private GameObject playerObj;

    [Header("------- Object -------")]
    [SerializeField] private GameObject playerCandy = null;

    public int good_item_count = 0;
    public int bad_item_count = 0;

    #region SingleTon

    private static TutorialManager _instance;

    public static TutorialManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<TutorialManager>();
                if (_instance == null)
                {
                    _instance = new GameObject("TutorialManager").AddComponent<TutorialManager>();
                }
            }
            return _instance;
        }
    }
    #endregion

    private void Awake()
    {
        playerData = Resources.Load<PlayerData>("SO/" + "PlayerData");

        SetPlayerValue();
    }

    private void Start()
    {
        // Connect PlayerObj
        playerData = Resources.Load<PlayerData>("SO/" + "PlayerData");

        state = Tutorial_State.isStory;
        playerObj = GameObject.Find("Player");
    }

    private void SetPlayerValue()
    {
        playerData.speed = 6;
        playerData.runspeed = 9;
        playerData.jumpForce = 1;
    }

    public void ChangeState(Tutorial_State _state)
    {
        state = _state;
    }

    public void GivePlayerCandy_Cane()
    {
        playerCandy.SetActive(true);
    }

    private void NextScen()
    {
        SceneManager.LoadScene("Main");
    }
}
