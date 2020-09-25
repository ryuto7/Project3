using UnityEngine;
using UnityEngine.UI;

public class EventPick : MonoBehaviour
{

    [SerializeField] Text text=default;
    public bool isTyping;
    public int eventProgressa;
    void Start()
    {
        //Debug.Log("イベント数 "+ EventDateBase.instance.date.Length);
        //RandomEvent(1);
    }
    private void FixedUpdate()
    {
        //RandomEvent(1);
    }
    public void DiceRoll()
    {
        int dice = Random.Range(1, 101);
        Debug.Log(dice);
    }


    public void RandomEvent(int number) // 1=イベントタイプ 1～10階          //文字流れていないときのみ動作 istyping;
    {
        if (!isTyping)
        {


            switch (eventProgressa)//進行度
            {
                case 0:     //イベント発生
                    //eventProgressa++; //進行度あげる
                    var eventNo = Random.Range(1, EventDateBase.instance.date.Length);//イベント数最大値までランダム
                    if (number >= EventDateBase.instance.date[eventNo].difficult)//1以下
                    {
                        Debug.Log(EventDateBase.instance.date[eventNo].name + "が発生"); //イベント名
                        text.text = EventDateBase.instance.date[eventNo].talk0;//会話発生
                    }
                    else
                    {
                        //初期化
                        Debug.Log("リロール");
                        isTyping = false;
                        eventProgressa = 0;
                        RandomEvent(number);//やり直し
                    }
                    break;

                case 1:
                    eventProgressa++;

                    break;
            }
        }
    }


}
