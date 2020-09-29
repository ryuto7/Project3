using UnityEngine;

public class IsAutoButton : MonoBehaviour
{
    [Header("参照")]
    [SerializeField] GameObject onButton;
    [SerializeField] GameObject offButton;

    public bool isAuto;
    bool isOption; //Auto実行中にばぐらないように

    public void ButtonIsAutoON()
    {
        if (!isOption)
        {
            isAuto = true;
            isOption = true;
            offButton.SetActive(false);
            onButton.SetActive(true);
            Debug.Log("オートモード");
        }
    }
    public void ButtonIsAutoOFF()
    {
        if(isOption)
        {
            isAuto = false;
            isOption = false;
            onButton.SetActive(false);
            offButton.SetActive(true);
            Debug.Log("オートモード解除");
        }

    }
}
