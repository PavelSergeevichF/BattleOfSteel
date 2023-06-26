using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelMenuController : IInitialization
{
    private PanelMenuView _panelMenuView;

    public PanelMenuController(PanelMenuView panelMenuView)
    {
        _panelMenuView = panelMenuView;
        panelMenuView.Account.onClick.AddListener(ClicOnAccount);
        panelMenuView.Shop.onClick.AddListener(ClicOnShop);
        panelMenuView.Legion.onClick.AddListener(ClicOnLegion);
        panelMenuView.Settings.onClick.AddListener(ClicOnSettings);
        panelMenuView.Events.onClick.AddListener(ClicOnEvents);
        panelMenuView.Back.onClick.AddListener(ClicOnBack);
        panelMenuView.Exit.onClick.AddListener(ClicOnExit);
    }

    public void Init()
    {
    }

    private void ClearPanel()
    {
        _panelMenuView.AccountPanel  .SetActive(false);
        _panelMenuView.StorePanel    .SetActive(false);
        _panelMenuView.LegionPanel   .SetActive(false);
        _panelMenuView.SettingsPanel .SetActive(false);
        _panelMenuView.EventPanel    .SetActive(false);
        _panelMenuView.ExitPanel     .SetActive(false);
    }
    private void ClicOnAccount()
    {
        ClearPanel();
        _panelMenuView.AccountPanel.SetActive(true);
    }
    private void ClicOnShop()
    {
        ClearPanel();
        _panelMenuView.StorePanel.SetActive(true);
    }
    private void ClicOnLegion()
    {
        ClearPanel();
        _panelMenuView.LegionPanel.SetActive(true);
    }
    private void ClicOnSettings()
    {
        ClearPanel();
        _panelMenuView.SettingsPanel.SetActive(true);
    }
    private void ClicOnEvents()
    {
        ClearPanel();
        _panelMenuView.EventPanel.SetActive(true);
    }
    private void ClicOnBack()
    {
        ClearPanel();
        _panelMenuView.PanelMenu.SetActive(false);
    }
    private void ClicOnExit()
    {
        ClearPanel();
        _panelMenuView.ExitPanel.SetActive(true);
    }
}
