using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using System;
public class EnemyDate : MonoBehaviour
{
    #region  データベース
    [Serializable]
    public class EnemyName
    {
        [Header("名前 強さ ステータス")]
        public string name;
        [ShowAssetPreview]
        public Sprite sprite;
        public int difficulty;
        public int hp;
        public int atk;
        public int def;
        public int lck;
        public int spd;
        public int gold;
    }
    [ReorderableList]
    public EnemyName[] date;
    #endregion


    #region シングルトンの実装
    static public EnemyDate instance;
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
