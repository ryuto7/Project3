using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.UI;

public class ItemGet : MonoBehaviour
{
    [SerializeField] GameObject content;
    [SerializeField] GameObject prefabItem;
    [SerializeField] ItemPrefab csItemPrefab;


    public void ButtonCreat(int itemNo)
    {
        GameObject prefab = (GameObject)Instantiate(prefabItem);
        csItemPrefab.ItemNo = itemNo;

        prefab.transform.SetParent(content.transform, false);
    }
}
