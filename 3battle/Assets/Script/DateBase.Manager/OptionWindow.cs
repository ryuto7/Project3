
using UnityEngine;
using DG.Tweening;
using NaughtyAttributes;

public class OptionWindow : MonoBehaviour
{
    [Header("参照")]

    [Header("オプション画面")]
    [SerializeField]
    RectTransform rectTran;
    [Header("ジャンプ変数")]
    [SerializeField] float jumpPower;
    [SerializeField] int numJumps;
    [SerializeField] float durationIn;
    [SerializeField] float durationOut;
    [Header("メニュー")]
    [SerializeField] GameObject menu;





    [Button("OptionIn")]
    public void OptionIn()
    {
        if (GameManager.instance.gameMode == 0)
        {
            Sequence seq = DOTween.Sequence();
            seq.SetEase(Ease.OutBounce);
            seq.Append(rectTran.DOLocalJump(new Vector3(0f, 0f, 0f), jumpPower, numJumps, durationIn));
            GameManager.instance.gameMode = 1; //ゲームモード変更
            SoundDateBase.instance.SE_Option();
            Debug.Log("オプションIn");

        }
    }

    [Button("OptionOut")]
    public void OptionOut()
    {
        Sequence seq = DOTween.Sequence();
        seq.SetEase(Ease.OutBounce);
        seq.Append(rectTran.DOLocalJump(new Vector3(0f, 2000f, 0f), jumpPower, numJumps, durationOut));
        GameManager.instance.gameMode = 0;
        SoundDateBase.instance.SE_Option();
        Debug.Log("オプションOut");
    }

}
