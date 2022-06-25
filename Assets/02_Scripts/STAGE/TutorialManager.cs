using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
    public GameObject[] items = null;
    public List<Transform> points = new List<Transform>();

    [Header("------- UI -------")]
    public Text itemCnt = null;
    public Image itemGaze = null;

    public int good_item_count = 0;

    private readonly WaitForSeconds delay = new WaitForSeconds(3f);

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

        SetPlayerValue(6, 7.5f, 1);
    }

    private void Start()
    {
        // Connect PlayerObj
        playerData = Resources.Load<PlayerData>("SO/" + "PlayerData");

        state = Tutorial_State.isStory;
        playerObj = GameObject.Find("Player");
        ItemTextUpdate();
        itemGaze.fillAmount = 0f;
    }

    public void SetPlayerValue(float _speed, float _runSpeed, float _jumpForce)
    {
        playerData.speed = _speed;
        playerData.runspeed = _runSpeed;
        playerData.jumpForce = _jumpForce;
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

    public void ItemTextUpdate()
    {
        itemCnt.text = $"{good_item_count}";

        if (itemGaze.fillAmount >= 1)
        {
            GameManager.Instance.SetPlayerValues();
            NextScen();
        }

        itemGaze.fillAmount += 0.08f;
    }

    public void ReadySpawnItems()
    {
        StartCoroutine(Spawner());
    }

    private IEnumerator Spawner()
    {
        //yield return new WaitForSeconds(8f);

        while (true)
        {
            SpawnItems();
            yield return delay;
        }
    }

    private void SpawnItems()
    {
        var _rand_item = Random.Range(0, items.Length);
        var _rand_pos = Random.Range(0, points.Count);

        var _item = Instantiate(items[_rand_item], points[_rand_pos]);

        Debug.Log($"{_item.name} »ý¼º!");

    }
}
