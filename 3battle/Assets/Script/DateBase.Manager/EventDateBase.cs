using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using NaughtyAttributes;
public class EventDateBase : MonoBehaviour
{    //データベース
    [Serializable]
 
    public class Date
    {

        [Header("イベントネーム")]
        public string name;
        [Header("イベント難易度")]
        public int difficult;

        [Header("はなす0 初めてのイベント")]
        [ResizableTextArea]
        [TextArea]
        public string talk0;
        /*[Header("はなす1 hpで変化")]
        [ResizableTextArea]
        [TextArea]
        public string talk1;
        [Header("はなす2 low hpで変化")]
        [ResizableTextArea]
        [TextArea]
        public string talk2;
        */
        [Header("アイテム所持フラグ")]
        public bool isSword;
        public bool isBow;
        public bool isRod;
        public bool isFood;
        public bool isPot;

        public int isHpPot;
        [Header("確率1～100")]
        public int event1per;
        public int event2per;
        public int event3per;
        [Header("イベント結果 Good<Bad<Normal")]
        [ResizableTextArea]
        [TextArea]
        public string result1;
        [ResizableTextArea]
        [TextArea]
        public string result2;
        [ResizableTextArea]
        [TextArea]
        public string result3;

        [Header("使用画像")]
        public Sprite sprite;
    }
    [ReorderableList]   
    public Date[] date;






    #region シングルトンの実装
    static public EventDateBase instance;
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
