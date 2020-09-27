using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public class Gacha : MonoBehaviour
{
    [SerializeField] ItemGet csItemGet;
    public int itemNo;
    [SerializeField] StatusDisplay csStatusDisplay;

    public void GahcaGetItem()
    {
        if (Status.instance.gold > 0) //goldとgamemode
        {
            SoundDateBase.instance.SE_Gacha();
            Status.instance.gold -= 1;
            int itemNo = Random.Range(0, ItemDateBase.instance.date.Length);
            var item = ItemDateBase.instance.date[itemNo];
            csItemGet.ButtonCreat(itemNo);
            csStatusDisplay.SetStatus();
        }
        else
            SoundDateBase.instance.SE_GachaFalse();
    }


}
