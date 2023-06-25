using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class StartScenButtonPanelController : IExecute
{
    private MainButtonPanelView _buttonPanelView;

    public StartScenButtonPanelController(MainButtonPanelView buttonPanelView)
    {
        _buttonPanelView = buttonPanelView;
        _buttonPanelView.MineMenuButton.onClick.AddListener(OpenPanelMine);
        _buttonPanelView.ParametrMenuButton.onClick.AddListener(OpenPanelParametr);
        _buttonPanelView.HangarButton.onClick.AddListener(OpenPanelHangar);
    }

    public void Execute()
    {
    }

    private void OpenPanelMine() => _buttonPanelView.MineMenuPanel.SetActive(true);
    private void OpenPanelParametr() => _buttonPanelView.ParametrPanel.SetActive(true);

    private void OpenPanelHangar() => _buttonPanelView.HangarPanel.SetActive(true);

}
