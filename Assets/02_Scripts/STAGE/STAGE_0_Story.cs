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
                // 으악ㄱ,,, 어지러워,,,,,
                checkEndDotween = false;
                DoTweenColorChange(0.8f, 4f, textBackImg);

                DotweenShowText(storyText[0], typingSpeed, checkEndDotween, textTrn);
                break;

            case 1:
                // 엥??! 여긴 어디,,?지??
                checkEndDotween = false;

                DotweenShowText(storyText[1], typingSpeed, checkEndDotween, textTrn);
                break;

            case 2:
                // (꼬르를륽ㄱ..)
                checkEndDotween = false;
                DotweenShowText(storyText[2], typingSpeed, checkEndDotween, textTrn);
                break;

            case 3:
                // 마침 배가 고픈데.. 저 음식들좀 먹어야겠다!
                checkEndDotween = false;
                DotweenShowText(storyText[3], typingSpeed, checkEndDotween, textTrn);
                break;

            case 4:
                // 갑자기?? 이 사탕은 뭐지?! 먹을 수 있는건가??
                checkEndDotween = false;

                TutorialManager.Instance.GivePlayerCandy_Cane();
                DotweenShowText(storyText[4], typingSpeed, checkEndDotween, textTrn);
                break;

            case 5:
                // 좌클릭을 눌러 사탕을 휘두르세요
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
        Debug.Log("눌러써요 버튼을!\n");
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
