using System;
using UnityEngine;
using UnityEngine.UI;
using NaughtyAttributes;

public class ItemDateBase : MonoBehaviour
{
    #region  データベース
    [Serializable]

    public class Date
    {

        [Header("No 名前")]
        public string name;
        [Header("レア度")]
        public int rare;
        [Header("使用画像")]
        [ShowAssetPreview]
        public Sprite sprite;
        [Header("説明")]
        [TextArea]
        public string describe;
        [Header("HP回復力")]
        public int HpHeal;
        [Header("攻撃力")]
        public int atk;
        [Header("防御")]
        public int def;
        [Header("運")]
        public int lck;
        [Header("はやさ")]
        public int spd;
        [Header("個数")]
        public int number;



        [Header("アイテムタイプ 1=使用 2=武器 3=大切なもの")]
        public int type;

    }
    //[ReorderableList]
    public Date[] date;
    #endregion




    #region シングルトンの実装
    static public ItemDateBase instance;
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


