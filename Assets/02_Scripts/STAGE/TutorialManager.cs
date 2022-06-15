using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    private static TutorialManager _instance;
    public Tutorial_State state { get; private set; }

    [Header("------- Player -------")]
    private GameObject playerObj;


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

}
