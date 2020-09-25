using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NaughtyAttributes;
public class ItemButton : MonoBehaviour
{
    [Header("参照")]
    public GameObject content;//キャンバス
    public GameObject button;
    public ScrollRect scrollRect;
    [SerializeField] Text text;
    [SerializeField] Image image;

    void Start()
    {

    }




    [Button("button Creat")]
    public void ButtonCreat()
    {
        GameObject prefab = (GameObject)Instantiate(button);
        prefab.transform.SetParent(content.transform, false);

    }



}
