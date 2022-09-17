using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonPrefab : MonoBehaviour
{
    private int Num = 1;
    public Text NumText;
    public GameObject Director;
    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(OnClicked_Button);
    }

    
    void Update()
    {
        
    }

    private void OnClicked_Button()
    {
        Director.GetComponent<GameDirector>().OnClickedButton_Binded();
    }

    public void SetText(string Str)
    {
        NumText.text = Str;
    }

    public int GetNum() { return Num; }
    public void SetNum(int num)
    {
        Num = num;
    }
}
