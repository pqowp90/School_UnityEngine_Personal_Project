using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class STAGE_0_Story : MonoBehaviour
{
    [Header("--------- Objects ---------")]
    [SerializeField] private Text textTrn = null;
    [SerializeField] private GameObject PlayerObj = null;
    [SerializeField] private string[] storyText = null;

    [Header("--------- Values ---------")]
    [SerializeField] private float typingSpeed = 2f;

    [Header("--------- PassStoryBtn ---------")]
    [SerializeField] private Button textPassBtn = null;

    private int index = 1;
    private int currentText = 0;

    private bool checkEndDotween = false;

    private void Start()
    {
        currentText = 0;
        LoadingStory(index);
    }

    private void Update()
    {
        //Debug.Log(checkEndDotween);
    }

    private void LoadingStory(int _num)
    {
        switch (_num)
        {
            case 1:
                checkEndDotween = false;
                DotweenShowText(storyText[0], typingSpeed, checkEndDotween);
                break;

            case 2:
                checkEndDotween = false;
                DotweenShowText(storyText[1], typingSpeed, checkEndDotween);
                break;

            case 3:
                checkEndDotween = false;
                DotweenShowText(storyText[2], typingSpeed, checkEndDotween);
                break;

            case 4:
                checkEndDotween = false;
                DotweenShowText(storyText[3], typingSpeed, checkEndDotween);
                break;

            case 5:
                checkEndDotween = false;
                DotweenShowText(storyText[4], typingSpeed, checkEndDotween);
                break;
        }
    }

    private void DotweenShowText(string _text, float _time, bool _checkEnd)
    {
        Sequence _seq = DOTween.Sequence();
        _seq.Append(textTrn.DOText(_text, _time));
        _seq.AppendCallback(() => checkEndDotween = true);
    }

    public void OnClickTypingPassBtn()
    {
        Debug.Log("눌러써요 버튼을!\n");
        if (checkEndDotween == false) return;
        else
        {
            ++index;
            textTrn.text = null;
            LoadingStory(index);
        }
    }
}
