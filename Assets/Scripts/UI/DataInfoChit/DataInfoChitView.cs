using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataInfoChitView : MonoBehaviour
{
    [SerializeField] private List<Text> _text;
    void Start()
    {
        DataInfoChitController.dataInfoChitView = this;
    }

    void Update()
    {
        
    }
    public void SetText(int line, string txt)
    {
        if (line < _text.Count-1)
        {
            _text[line-1].text = txt;
        }
        else 
        {
            Debug.Log($"Обращение к номеру {line} строки больше чем количество строк! ");
        }
        
    }
}
