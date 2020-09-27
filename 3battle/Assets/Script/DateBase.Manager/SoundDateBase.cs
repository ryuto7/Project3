using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundDateBase : MonoBehaviour
{
    #region    //シングルトン化
    static public SoundDateBase instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion

    [Header("____BGM____")]
    public AudioSource bgm;
    public AudioClip bgm1;
    public AudioClip bgm2;
    public AudioClip bgm3;
    public AudioClip bgm4;

    [Header("____SE____")]
    public AudioSource se;
    [Header("SE入れ")]
    public AudioClip typeWriter;//Main画面
    [Header("テキスト流れる音")]
    public AudioClip log;
    [Header("攻撃音")]
    public AudioClip attack_normal;
    public AudioClip attack_crit;
    [Header("勝利音")]
    public AudioClip win;
    public AudioClip lose;

    [Header("ガチャ")]
    public AudioClip gacha;
    public AudioClip gachaFalse;
    public AudioClip used;
    [Header("UI")]
    public AudioClip continueButton;
    public AudioClip option;
    /*40 と 41がちゃで使えそう*/
    #region BGM
    public void BGM_01()
    {
        bgm.PlayOneShot(bgm1);
    }

    #endregion
    private void Start()
    {
        BGM_01();
    }

    #region SE
    public void SE_TypeWeiter()
    {
        se.PlayOneShot(typeWriter);
    }
    public void SE_Log()
    {
        se.PlayOneShot(log);
    }
    public void SE_Attack_Normal()
    {
        se.PlayOneShot(attack_normal);
    }
    public void SE_Attack_Crit()
    {
        se.PlayOneShot(attack_crit);
    }
    public void SE_Win()
    {
        se.PlayOneShot(win);
    }
    public void SE_Lose()
    {
        se.PlayOneShot(lose);
    }
    public void SE_Gacha()
    {
        se.PlayOneShot(gacha);
    }
    public void SE_GachaFalse()
    {
        se.PlayOneShot(gachaFalse);
    }
    public void SE_Continue()
    {
        se.PlayOneShot(continueButton);
    }
    public void SE_Used()
    {
        se.PlayOneShot(used);
    }
    public void SE_Option()
    {
        se.PlayOneShot(option);
    }
    #endregion
}
