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

    private Image backImg = null;

    private int index = 0;
    private int currentText = 0;

    private bool checkEndDotween = false;

    private void Start()
    {
        backImg = GetComponent<Image>();
        DoTweenColorChange();

        currentText = 0;
        textTrn.text = null;
        LoadingStory(index);
    }

    private void DoTweenColorChange()
    {
        backImg.DOFade(0.5f, 8f);
    }

    private void LoadingStory(int _num)
    {
        switch (_num)
        {
            case 0:
                // ���Ǥ�,,, ��������,,,,,
                checkEndDotween = false;
                DotweenShowText(storyText[0], typingSpeed, checkEndDotween);
                break;

            case 1:
                // ��??! ���� ���,,?��??
                checkEndDotween = false;
                DotweenShowText(storyText[1], typingSpeed, checkEndDotween);
                break;

            case 2:
                // (�������Z��..)
                checkEndDotween = false;
                DotweenShowText(storyText[2], typingSpeed, checkEndDotween);
                break;

            case 3:
                // ��ħ �谡 ���µ�.. �� ���ĵ��� �Ծ�߰ڴ�!
                checkEndDotween = false;
                DotweenShowText(storyText[3], typingSpeed, checkEndDotween);
                break;

            case 4:
                // ���ڱ�?? �� ������ ����?! ���� �� �ִ°ǰ�??
                checkEndDotween = false;
                TutorialManager.Instance.GivePlayerCandy_Cane();
                DotweenShowText(storyText[4], typingSpeed, checkEndDotween);
                break;

            case 5:
                // [��Ŭ���� �غ�����]
                TutorialManager.Instance.ChangeState(Tutorial_State.isPlay);
                checkEndDotween = false;
                DotweenShowText(storyText[5], typingSpeed, checkEndDotween);
                break;

            case 6:
                // ��!! �̰Ž� ����??!!!
                checkEndDotween = false;
                DotweenShowText(storyText[6], typingSpeed, checkEndDotween);
                break;

            case 7:
                // (����������������) 
                checkEndDotween = false;
                DotweenShowText(storyText[7], typingSpeed, checkEndDotween);
                break;

            case 8:
                // �ƿ� �˰ھ� ���� ���� ������ ������!
                checkEndDotween = false;
                DotweenShowText(storyText[8], typingSpeed, checkEndDotween);

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
        Debug.Log("������� ��ư��!\n");
        if (checkEndDotween == false) return;
        else
        {
            ++index;
            textTrn.text = null;
            LoadingStory(index);
        }
    }
}
