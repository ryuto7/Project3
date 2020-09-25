
using UnityEngine;
using DG.Tweening;
using NaughtyAttributes;

public class GameOverWindow : MonoBehaviour
{
    [Header("参照")]
    [SerializeField]
    StatusDisplay csStatusDisplay;

    [Header("ゲームオーバー")]
    [SerializeField]
    RectTransform rectTran;
    [SerializeField]
    float durationIn;
    [SerializeField]
    float durationOut;
    [Button("GameOverIn")]



    public void GameOverIn()
    {
        Sequence seq = DOTween.Sequence();
        seq.SetEase(Ease.OutBounce);
        seq.Append(rectTran.DOLocalMove(new Vector3(0f, 0f, 0f), durationIn));
        GameManager.instance.gameMode = 1; //ゲームモード変更
        Debug.Log("gameover in");
    }

    [Button("back")]
    public void GameOverOut()
    {
        Sequence seq = DOTween.Sequence();
        seq.SetEase(Ease.OutBack);
        seq.Append(rectTran.DOLocalMove(new Vector3(0f, 2000, 0f), durationOut));

        Status.instance.hp = 10;
        csStatusDisplay.SetStatus();

        GameManager.instance.gameMode = 0; //ゲームモード変更
        Debug.Log("gameover out");
    }


    void NewGame()
    {

    }

}
