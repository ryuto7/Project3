using System.Collections;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class Battle : MonoBehaviour
{
    [Header("参照")]
    [SerializeField] StatusDisplay csStatusDisplay;
    public ScrollRect scrollRect; //text 下固定する 
    [SerializeField] Image image; //敵のイメージを挿入
    [SerializeField] Text text; //ログtext
    [SerializeField] GameOverWindow csGameOverWindow;
    [SerializeField] Text floorText;

    bool isBattle; //戦闘中
    bool isLog;//ボタン制御
    int turnNumber; //turn数
    bool isAuto; //使う予定
    int floorNumber; //階層

    [Header("戦闘ログ速度ディレイ")]
    public float delay; //ログディレイ
    int enemyHP;//hp保存 リセット用

    [Header("敵アニメーション")]
    [SerializeField]
    RectTransform enemyImage;


    private void Start()
    {
        text.text = "\n\n\n\n\n\n\n\n\n";//下に表示するための改行
        text.text = "おはろ～";
        UnderPositionText(0);
        image.sprite = EnemyDate.instance.date[0].sprite;
    }


    #region 戦闘関連
    public IEnumerator BattleMatching() //敵選択 最期に初期化メソッド  
    {
        if (GameManager.instance.gameMode == 0)//通常時のみ動作
        {
            GameManager.instance.gameMode = 1; //モード移行 最期に戻す
            int EnemyNo = Random.Range(0, EnemyDate.instance.date.Length);
            var enemy = EnemyDate.instance.date[EnemyNo];
            //Debug.Log("No" + EnemyNo + " " + enemy.name + " 敵のデータ数" + EnemyDate.instance.date.Length);
            text.text = "";//テキスト初期化
            if (floorNumber >= enemy.difficulty)//難易度判定

            {
                image.sprite = enemy.sprite;
                text.text += "\n\n" + enemy.name + "があらわれた";
                UnderPositionText(1);
                SaveEnemyDate(EnemyNo, true); //敵保存
                //バトルの後 結果に移行
                yield return StartCoroutine(MainBattle(EnemyNo));
                BattleResult(EnemyNo);
                //リセットに移行 
                yield return new WaitForSeconds(delay);
                BattleReset(EnemyNo);//終了処理
            }
            else
            {   //リロール
                GameManager.instance.gameMode = 0;
                StartCoroutine(BattleMatching());
                Debug.Log("リロールしました");
            }
        }
    }


    private IEnumerator MainBattle(int EnemyNo) //戦闘処理 Loop //自分と相手の行動
    {
        var enemy = EnemyDate.instance.date[EnemyNo];
        var my = Status.instance;


        while (!isBattle)
        {
            yield return new WaitForSeconds(delay);
            turnNumber++;
            text.text += "\n【" + turnNumber + "ターン目】";
            UnderPositionText(0);

            if (my.spd >= enemy.spd)//はやさ判定 勝ち
            {
                if (my.hp >= 0 && enemy.hp >= 0)
                {
                    Attack(EnemyNo);
                    UnderPositionText(1);

                    if (my.hp > 0 && enemy.hp > 0)
                    {
                        yield return new WaitForSeconds(delay);//相手の行動
                        Attack_Enemy(EnemyNo);
                        UnderPositionText(1);
                    }
                }
            }
            if (my.spd < enemy.spd)//はやさ判定 負け
            {

                if (my.hp > 0 && enemy.hp > 0)
                {
                    Attack_Enemy(EnemyNo);

                    UnderPositionText(1);

                    if (my.hp >= 0 && enemy.hp >= 0)
                    {
                        Attack(EnemyNo);
                        UnderPositionText(1);
                    }
                }
            }
            if (my.hp <= 0 || enemy.hp <= 0) //戦闘終了
            {
                yield return new WaitForSeconds(delay);
                isBattle = true;
                break;
            }
        }
    }

    
    void BattleReset(int EnemyNo) //戦闘後 初期化
    {
        //ｼｮｰﾄｶｯﾄ
        var enemy = EnemyDate.instance.date[EnemyNo];
        var my = Status.instance;

        //初期化処理
        //Debug.Log("終了  自分のhpが" + my.hp + "敵のhpが" + enemy.hp);
        isBattle = false;
        turnNumber = 0;
        SaveEnemyDate(EnemyNo, false);//HP初期化

        isLog = false;//ボタン押せる


        if (isAuto)//オート実装
        {
            StartCoroutine(BattleMatching());
        }
    }

    void BattleResult(int EnemyNo) //戦闘結果処理
    {        //ｼｮｰﾄｶｯﾄ
        var enemy = EnemyDate.instance.date[EnemyNo];
        var my = Status.instance;


        if (my.hp <= 0)
        {   //負けの処理
            text.text += ("\n" + enemy.name + "に負けた");
            SoundDateBase.instance.SE_Lose();
            my.hp = 0; //マイナスにしない
            UnderPositionText(0);
            GameManager.instance.gameMode = 0; //モードリセット
            csGameOverWindow.GameOverIn();
            NextFloor(false);
        }

        if (enemy.hp <= 0)
        {   //勝ち
            text.text += ("\n" + enemy.name + "を倒した");
            text.text += ("\n" + enemy.gold + "ゴールド手に入れた");
            SoundDateBase.instance.SE_Win();
            my.gold += enemy.gold;
            UnderPositionText(0);
            GameManager.instance.gameMode = 0; //モードリセット
            NextFloor(true);
        }
    }

    void Attack(int EnemyNo)
    {//ｼｮｰﾄｶｯﾄ
        var enemy = EnemyDate.instance.date[EnemyNo];
        var my = Status.instance;

        //クリティカル処理
        int randomLuck = Random.Range(0, 100);
        if (my.lck > randomLuck || turnNumber > 50)
        {
            enemy.hp -= (my.atk * 3);
            text.text += "\nクリティカル!!!" + "\n" + enemy.name + "に" + (my.atk * 3) + "のダメージ";
            SoundDateBase.instance.SE_Attack_Crit();
        }
        else
        {
            //通常攻撃
            int dmg = my.atk - enemy.def;
            if (dmg < 0)  
                dmg = 0;
            enemy.hp -= dmg;
            //ログに出る
            text.text += "\n" + enemy.name + "に" + dmg + "のダメージ";
            SoundDateBase.instance.SE_Attack_Normal();
        }
        //Debug.Log("自分の攻撃 相手のHP" + enemy.hp);
    }

    void Attack_Enemy(int EnemyNo) //敵の攻撃
    {//ｼｮｰﾄｶｯﾄ
        var enemy = EnemyDate.instance.date[EnemyNo];
        var my = Status.instance;

        //クリティカル処理
        int randomLuck = Random.Range(0, 100);
        if (enemy.lck > randomLuck || turnNumber > 50)
        {
            my.hp -= (enemy.atk * 3);
            text.text += "\nクリティカル!!!" + "\n自分に" + (enemy.atk * 3) + "のダメージ";
            SoundDateBase.instance.SE_Attack_Crit();
            Debug.Log("クリティカル判定");
        }
        else//通常攻撃
        {
            int dmg = enemy.atk - my.def;
            if (dmg < 0)    //防御が上回った時の処理
                dmg = 0;
            my.hp -= dmg;
            //↓ログ
            text.text += "\n" + "自分に" +dmg+ "のダメージ";
            SoundDateBase.instance.SE_Attack_Normal();
        }
        //Debug.Log(enemy.name + "の攻撃 自分のHP" + my.hp);
    }
    #endregion

    #region 管理メソッド
    void UnderPositionText(int sound) //text.textの行の次に必須
    {
        switch (sound)
        {
            case 0: //サウンドなし
                text.GetComponent<ContentSizeFitter>().SetLayoutVertical();//<-これ追加
                scrollRect.verticalNormalizedPosition = 0.0f;
                break;

            case 1:
                text.GetComponent<ContentSizeFitter>().SetLayoutVertical();//<-これ追加
                scrollRect.verticalNormalizedPosition = 0.0f;
                SoundDateBase.instance.SE_Log();
                break;
        }
        csStatusDisplay.SetStatus();

    }
    void SaveEnemyDate(int number  ,bool save ) //敵のナンバー , hp ,save ! load
    {
        if (save)
        {
            enemyHP = EnemyDate.instance.date[number].hp; //hp保存
            Debug.Log(EnemyDate.instance.date[number].name+ "のHP"+ enemyHP + "をenemyHPに保存");
        }
        if (!save)
        {
            EnemyDate.instance.date[number].hp = enemyHP; //hp初期化
            Debug.Log(EnemyDate.instance.date[number].name + "のHPを"+enemyHP+"にリセット");
        }
    }

    void NextFloor(bool win)
    {
        if (win)
        {
            floorNumber++;
            floorText.text = floorNumber + "F ";
        }
        if (!win)
        {
            floorNumber=0;
            floorText.text = floorNumber + "F ";
        }
    }

    #endregion

    #region ボタン
    [Button("ランダム戦闘ボタン")]
    public void BattleB()
    {
        if (!isLog && Status.instance.hp > 0)
        {
            isLog = true;
            StartCoroutine(BattleMatching());
        }
    }
    [Button("HP回復")]
    public void Battlehpseet()
    {
        Status.instance.hp += 10;
    }
    [Button("自殺")]
    public void bttledead()
    {
        Status.instance.hp = 0;
    }
    #endregion
}
