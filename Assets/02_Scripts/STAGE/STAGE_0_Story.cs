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
    [SerializeField] private Image textBackImg = null;

    // extra Sulmung Obj
    [SerializeField] private Image sulmungImage = null;
    [SerializeField] private Text sulmungText = null;

    [SerializeField] private string[] storyText = null;

    [Header("--------- Values ---------")]
    [SerializeField] private float typingSpeed = 2f;

    [Header("--------- PassStoryBtn ---------")]
    [SerializeField] private Button textPassBtn = null;


    private int index = 0;

    private bool checkEndDotween = false;

    private void Start()
    {
        //TutorialManager.Instance.ChangeState(Tutorial_State.isStory);
        GameManager.Instance.tutoState = Tutorial_State.isStory;
        textTrn.text = null;
        LoadingStory(index);
    }


    private void LoadingStory(int _num)
    {
        switch (_num)
        {
            case 0:
                // ���Ǥ�,,, ��������,,,,,
                checkEndDotween = false;
                DoTweenColorChange(0.8f, 4f, textBackImg);

                DotweenShowText(storyText[0], typingSpeed, checkEndDotween, textTrn);
                break;

            case 1:
                // ��??! ���� ���,,?��??
                checkEndDotween = false;

                DotweenShowText(storyText[1], typingSpeed, checkEndDotween, textTrn);
                break;

            case 2:
                // (�������Z��..)
                checkEndDotween = false;
                DotweenShowText(storyText[2], typingSpeed, checkEndDotween, textTrn);
                break;

            case 3:
                // ��ħ �谡 ���µ�.. �� ���ĵ��� �Ծ�߰ڴ�!
                checkEndDotween = false;
                DotweenShowText(storyText[3], typingSpeed, checkEndDotween, textTrn);
                break;

            case 4:
                // ���ڱ�?? �� ������ ����?! ���� �� �ִ°ǰ�??
                checkEndDotween = false;

                TutorialManager.Instance.GivePlayerCandy_Cane();
                DotweenShowText(storyText[4], typingSpeed, checkEndDotween, textTrn);
                break;

            case 5:
                // ��Ŭ���� ���� ������ �ֵθ�����
                checkEndDotween = false;

                CursorLock();
                //TutorialManager.Instance.ChangeState(Tutorial_State.isPlay);
                GameManager.Instance.tutoState = Tutorial_State.isPlay;
                textTrn.text = null;

                DoTweenColorChange(1, 0.8f, sulmungImage);
                DoTweenColorChange(0, 0.5f, textBackImg);

                DotweenShowText(storyText[5], typingSpeed, checkEndDotween, sulmungText);

                break;
        }
    }

    private void DotweenShowText(string _text, float _time, bool _checkEnd, Text _textTrn)
    {
        Sequence _seq = DOTween.Sequence();
        _seq.Append(_textTrn.DOText(_text, _time));
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


    private void DoTweenColorChange(float _value, float _dur, Image _targetImage)
    {
        _targetImage.DOFade(_value, _dur);
    }

    private void CursorLock()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
