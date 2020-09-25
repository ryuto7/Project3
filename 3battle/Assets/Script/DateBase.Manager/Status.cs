using NaughtyAttributes;
using UnityEngine;
using UnityEngine.UI;

public class Status : MonoBehaviour
{


    [Header("ステータス")]
    [MinValue(0)] public int gold;
    [MinValue(0)] public int hp;
    [MinValue(1)] public int atk;
    [MinValue(1)] public int def;
    [MinValue(1)] public int lck;
    [MinValue(1)] public int spd;


    public void DefaultStatus()
    {
        hp = 10;
        atk = 1;
        def = 1;
        lck = 1;
        spd = 1;
    }





    #region シングルトンの実装
    static public Status instance;
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
}
