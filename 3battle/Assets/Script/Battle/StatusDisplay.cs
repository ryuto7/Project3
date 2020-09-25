using UnityEngine;
using UnityEngine.UI;
public class StatusDisplay : MonoBehaviour
{
    [Header("参照  *未使用* ")]
    [SerializeField]Battle csBattle;
    [Header("ステータスtext")]
    [SerializeField] Text txtGold;
    [SerializeField] Text txtHP;
    [SerializeField] Text txtAtk;
    [SerializeField] Text txtDef;
    [SerializeField] Text txtLck;
    [SerializeField] Text txtSpd;

    [Header("数値監視")]
    bool isReflesh;
    
    private void Start()
    {
        SetStatus();
    }
    
    public void SetStatus()//ステータス更新
    {
        var my = Status.instance;
        txtGold.text = my.gold. ToString();
        txtHP.text = my.hp.ToString();
        txtAtk.text = my.atk.ToString();
        txtDef.text = my.def.ToString();
        txtLck.text = my.lck.ToString();
        txtSpd.text = my.spd.ToString();
    }




}
