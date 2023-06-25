using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelHangarController : IExecute
{
    private PanelHangarView _panelHangarView;

    private GameObject _hangarPanel;

    private List<Text> _text;

    public PanelHangarController(PanelHangarView panelHangarView)
    {
        _panelHangarView = panelHangarView;

        _hangarPanel = panelHangarView.ArmorPanel;

        _text = panelHangarView.TextInfo;
        panelHangarView.BackBot.onClick.AddListener(BeackBot);
        panelHangarView.NextBot.onClick.AddListener(NextBot);
        panelHangarView.Type1.onClick.AddListener(GetTypeBot1);
        panelHangarView.Type2.onClick.AddListener(GetTypeBot2);
        panelHangarView.Type3.onClick.AddListener(GetTypeBot3);
        panelHangarView.Type4.onClick.AddListener(GetTypeBot4);
        panelHangarView.Back.onClick.AddListener(Beack);
    }

    public void Execute()
    {
    }
    private void NextBot()
    { }
    private void BeackBot()
    { }
    private void GetTypeBot1()
    { }
    private void GetTypeBot2()
    { }
    private void GetTypeBot3()
    { }
    private void GetTypeBot4()
    { }
    private void Beack() =>  _hangarPanel.SetActive(false); 
}
