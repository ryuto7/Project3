using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NaughtyAttributes;

public class ItemPrefab : MonoBehaviour
{
    [Header("参照")]
    [SerializeField] Text text;
    [SerializeField] Image image;
    public int ItemNo;
    GameObject status;

    [Header("ステータス")]
    int hpHeal;
    int atk;
    int def;
    int lck;
    int spd;
    int type;
    private void Start()
    {
        //参照
        status = GameObject.FindGameObjectWithTag("TextManager");
        CreatButton();


        
    }

    void Type2()
    {
        var item = ItemDateBase.instance.date[ItemNo];
        if (item.type == 2)
        {
            item.number++;
        }

        CreatButton();
    }

    public void CreatButton()
    {
        //ボタンセット
        var item = ItemDateBase.instance.date[ItemNo];

        hpHeal = item.HpHeal;
        atk = item.atk;
        def = item.def;
        lck = item.lck;
        spd = item.spd;

        text.text = item.name;
        image.sprite = item.sprite;
    }

    //参照
    StatusDisplay csStatusDisplay;
    public void ButtonUseThis() //アイテム使用
    {
        var my = Status.instance;
        my.hp += hpHeal;
        my.atk += atk;
        my.def += def;
        my.lck += lck;
        my.spd += spd;

        status.GetComponent<StatusDisplay>().SetStatus();
        Destroy(this.gameObject);
    }


}
