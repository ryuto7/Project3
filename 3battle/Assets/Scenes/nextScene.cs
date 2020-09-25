using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using NaughtyAttributes;

public class nextScene : MonoBehaviour
{
    [Button("メイン画面へ")]
    public void MainScene() //シーンの切り替え
    {
        SceneManager.LoadScene("Main");
    }
    [Button("タイトル画面へ")]
    public void TitleScene() //シーンの切り替え
    {
        SceneManager.LoadScene("Title");
    }
    #region シングルトンの実装
    static public nextScene instance;
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
