using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class STAGE_0_Story : MonoBehaviour
{
    [Header("--------- Objects ---------")]
    [SerializeField] private Text textTrn = null;
    [SerializeField] private string[] text = null;
    [SerializeField] private Button textPassBtn = null;

    [Header("--------- Values ---------")]
    [SerializeField] private float typingSpeed = 2f;

    private int currentText = 0;

    private void Start()
    {
        GameManager.Instance.SetPlayerState(PlayerState.Tuto);
        currentText = 0;
        DotweenShowText(text[0], typingSpeed);
    }

    private void DotweenShowText(string _text, float _time)
    {
        textTrn.DOText(_text, _time);
    }

    public void OnClickTypingPassBtn()
    {
        Debug.Log("눌러써요 버튼을!\n");

    }
}
