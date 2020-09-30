using System;
using UnityEngine;
using NaughtyAttributes;
public class BackgroundDate : MonoBehaviour
{
    #region  データベース
    [Serializable]

    public class Date
    {
        [Header("No 名前")]
        public string name;
        [Header("No 名前")]
        public int no;
        [Header("使用画像")]
        [ShowAssetPreview]
        public Sprite sprite;
    }
    [ReorderableList]
    public Date[] date;
    #endregion


    #region    //シングルトン化
    static public BackgroundDate instance;
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
