using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InfoHelpPanelController: IInitialization
{
    private InfoHelpPanelView _infoHelpView;
    private SOInfoHelpTexts _sOInfoHelpTexts;

    public SOInfoHelpTexts SOInfoHelpTexts => _sOInfoHelpTexts;

    public InfoHelpPanelController(InfoHelpPanelView infoHelpView)
    {
        _infoHelpView = infoHelpView;
        _sOInfoHelpTexts = infoHelpView.SOInfoHelpTexts;
        infoHelpView.ClosePanel.onClick.AddListener(ClosePanel);
    }

    public void Init()
    {
    }
    private void ClosePanel()
    {
        _infoHelpView.InfoHelpPane.SetActive(false);
    }

    public void SetInform(SOInfoHelpText info)
    {
        _infoHelpView.InfoHelpPane.SetActive(true);
        _infoHelpView.HeadText.text = info.HelpTextHead;
        _infoHelpView.BodyText.text = info.HelpTextBody;
    }
}
