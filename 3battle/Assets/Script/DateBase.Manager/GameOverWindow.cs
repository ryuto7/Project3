
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
    [Header("ボタンディレイ 触らない")]
    public float delay;
    float delayTime;
    public bool setButton;
    private void Start()
    {
        //delayセット
        delay = durationIn;
    }
    private void FixedUpdate()
    {
        //delayセット
        if (setButton)
        {
            delayTime += Time.deltaTime;
        }
    }

    [Button("GameOverIn")]
    public void GameOverIn()
    {
        setButton = true;
        Sequence seq = DOTween.Sequence();
        seq.SetEase(Ease.OutBounce);
        seq.Append(rectTran.DOLocalMove(new Vector3(0f, 0f, 0f), durationIn));
        GameManager.instance.gameMode = 1; //ゲームモード変更
        Debug.Log("gameover in");
    }

    [Button("back")]
    public void GameOverOut()
    {
        if (delay <= delayTime)
        {
            Sequence seq = DOTween.Sequence();
            seq.SetEase(Ease.OutBack);
            seq.Append(rectTran.DOLocalMove(new Vector3(0f, 2000, 0f), durationOut));

            Status.instance.hp = 10;
            csStatusDisplay.SetStatus();

            GameManager.instance.gameMode = 0; //ゲームモード変更
            Debug.Log("gameover out");
            SoundDateBase.instance.SE_Continue();//se

            //ディレイの設定
            setButton = false;
            delayTime = 0f;
        }
    }


    void NewGame()
    {

    }

}
