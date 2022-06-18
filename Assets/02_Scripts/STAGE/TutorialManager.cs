using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class TutorialManager : MonoBehaviour
{
    private static TutorialManager _instance;
    public Tutorial_State state { get; private set; }

    [Header("------- Player -------")]
    private GameObject playerObj;

    [Header("------- Object -------")]
    [SerializeField] private GameObject StageMap = null;
    [SerializeField] private GameObject playerCandy = null;

    [SerializeField] private GameObject[] walls = null;

    public int good_item_count = 0;
    public int bad_item_count = 0;

    private int wall_num = 0;

    #region SingleTon
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

    private void Start()
    {
        // Connect PlayerObj
        state = Tutorial_State.isStory;
        playerObj = GameObject.Find("Player");
    }

    public void ChangeState(Tutorial_State _state)
    {
        state = _state;
    }

    public void MoveWall()
    {
        var _value = 0.2f;

        var _x = (StageMap.transform.localScale.x) - _value;
        var _y = (StageMap.transform.localScale.y) - _value;
        var _z = (StageMap.transform.localScale.z) - _value;
        ;
        StageMap.transform.DOScale(new Vector3(_x, _y, _z), 1f);
        ++wall_num;
        if (wall_num >= 5)
        {
            NextScen();
        }
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
