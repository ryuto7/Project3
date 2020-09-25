using UnityEngine;
using NaughtyAttributes;
using System.Diagnostics;
using Debug = UnityEngine.Debug;

public class GameManager : MonoBehaviour
{
    /* 通常時 アイドル状態 0
     * 一時停止 オプション　ゲームオーバー 1
     * 戦闘状態 2
    */
    public int gameMode;
    


    void GameStart()
    {
        switch (gameMode)
        {
            case 0:
                Debug.Log("0");
                break;
            case 1:
                Debug.Log("1");
                break;

            case 2:
                Debug.Log("2");
                break;
        }
    }

    void GameStop()
    {

    }



    #region シングルトンの実装
    static public GameManager instance;
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
