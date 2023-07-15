using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelHangarController : IExecute
{
    private ETypeBot _eTypeBot;
    private bool _hangarT_StoreF=true;
    private int _botActive = 0;
    private PanelHangarView _panelHangarView;

    private GameObject _hangarPanel;

    private List<Text> _text;
    private SOBotsData _sOBotsData;

    public PanelHangarController(PanelHangarView panelHangarView, SOUserData sOUserData)
    {
        _panelHangarView = panelHangarView;

        _hangarPanel = panelHangarView.ArmorPanel;

        _sOBotsData = sOUserData.BotsData;

        _text = panelHangarView.TextInfo;
        panelHangarView.BackBot.onClick.AddListener(BeackBot);
        panelHangarView.NextBot.onClick.AddListener(NextBot);
        panelHangarView.Type1.onClick.AddListener(GetTypeBot1);
        panelHangarView.Type2.onClick.AddListener(GetTypeBot2);
        panelHangarView.Type3.onClick.AddListener(GetTypeBot3);
        panelHangarView.Type4.onClick.AddListener(GetTypeBot4);
        panelHangarView.Select.onClick.AddListener(SelectBot);
        panelHangarView.SelectStoreOrHangar.onClick.AddListener(SelectHangarOrStore);
        panelHangarView.Back.onClick.AddListener(Beack);

        switch (_sOBotsData.eTypeBot)
        {
            case ETypeBot.LBT: GetTypeBot1(); break;
            case ETypeBot.SBT: GetTypeBot2(); break;
            case ETypeBot.LT: GetTypeBot3(); break;
            case ETypeBot.TT: GetTypeBot4(); break;
        }

    }

    public void Execute()
    {
    }
    private void NextBot()
    {
        SwitchBotModel(true);
    }
    private void BeackBot()
    {
        SwitchBotModel(false);
    }
    private void SwitchBotModel(bool next)
    {
        switch (_eTypeBot)
        {
            case ETypeBot.LBT: 
                SwitchModel(_sOBotsData.LBTBotsData, next);  
                break;
            case ETypeBot.SBT:
                SwitchModel(_sOBotsData.SBTBotsData, next);
                break;
            case ETypeBot.LT:
                SwitchModel(_sOBotsData.LTBotsData, next); 
                break;
            case ETypeBot.TT:
                SwitchModel(_sOBotsData.TTBotsData, next); 
                break;
        }
    }
    private void SwitchModel(SOBot BotsData, bool next)
    {
        if (next)
        {
            if (BotsData.BotActive < BotsData.BotsData.Count-1)
                BotsData.BotActive++;
            else
                BotsData.BotActive = 0;
        }
        else
        {
            if (BotsData.BotActive > 0)
                BotsData.BotActive--;
            else
                BotsData.BotActive = BotsData.BotsData.Count - 1;
        }
        _botActive = BotsData.BotActive;
        _text[0].text = BotsData.BotsData[_botActive].NameBot;
        Debug.Log($"Type {_eTypeBot}, BotActive {BotsData.BotActive}, neme {BotsData.BotsData[BotsData.BotActive].name}");
    }
    private void SelectBot()
    {
        if (_hangarT_StoreF)
        {
            _sOBotsData.eTypeBot=_eTypeBot;
            switch (_sOBotsData.eTypeBot)
            {
                case ETypeBot.LBT: _sOBotsData.ActivBot= _sOBotsData.LBTBotsData.BotsData[_sOBotsData.LBTBotsData.BotActive]; break;
                case ETypeBot.SBT: _sOBotsData.ActivBot = _sOBotsData.SBTBotsData.BotsData[_sOBotsData.SBTBotsData.BotActive]; break;
                case ETypeBot.LT: _sOBotsData.ActivBot= _sOBotsData.LTBotsData.BotsData[_sOBotsData.LTBotsData.BotActive]; break;
                case ETypeBot.TT: _sOBotsData.ActivBot = _sOBotsData.TTBotsData.BotsData[_sOBotsData.TTBotsData.BotActive]; break;
            }
            _sOBotsData.ActivBot.TypeBot = _sOBotsData.eTypeBot;
        }
        else
        {
        }
    }
    private void SelectHangarOrStore()
    {
        if (_hangarT_StoreF)
        {
            _hangarT_StoreF = false;
        }
        else 
        {
            _hangarT_StoreF = true;
        }
    }
    private void GetTypeBot1() => GetTypeBot(ETypeBot.LBT, 0);
    private void GetTypeBot2() => GetTypeBot(ETypeBot.SBT, 1);
    private void GetTypeBot3() => GetTypeBot(ETypeBot.LT, 2);
    private void GetTypeBot4() => GetTypeBot(ETypeBot.TT, 3);
    private void GetTypeBot(ETypeBot eTypeBot, int panel)
    {
        _eTypeBot = eTypeBot;
        ClearImag();
        string typeSTR = "";
        SOBot BotsData = _sOBotsData.LBTBotsData;
        switch (eTypeBot)
        {
            case ETypeBot.LBT: 
                { 
                    typeSTR = "หมา";
                    _botActive = _sOBotsData.LBTBotsData.BotActive;
                    BotsData = _sOBotsData.LBTBotsData;
                }  break;
            case ETypeBot.SBT:
                {
                    typeSTR = "ัมา";
                    _botActive = _sOBotsData.SBTBotsData.BotActive;
                    BotsData = _sOBotsData.SBTBotsData;
                } break;
            case ETypeBot.LT: 
                {
                    typeSTR = "หา";
                    _botActive = _sOBotsData.LTBotsData.BotActive;
                    BotsData = _sOBotsData.LTBotsData;
                } break;
            case ETypeBot.TT: 
                { 
                    typeSTR = "าา";
                    _botActive = _sOBotsData.TTBotsData.BotActive;
                    BotsData = _sOBotsData.TTBotsData;
                }  break;
        }
        _text[1].text = typeSTR;
        _text[0].text = BotsData.BotsData[_botActive].NameBot;
        _panelHangarView.TypePanels[panel].SetActive(true);
    }
    private void ClearImag()
    { 
        foreach (var img in _panelHangarView.TypePanels) img.SetActive(false); 
    }
    private void Beack() =>  _hangarPanel.SetActive(false); 
}
