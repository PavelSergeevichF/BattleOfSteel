using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LicenseController : IInitialization
{
    private LicenseView _licenseView;

    public LicenseController(LicenseView licenseView)
    {
        _licenseView = licenseView;
        if (!licenseView.SOUserData.Authorization)
        { 
            SetActivePanel();
        }
        licenseView.Accept.onClick.AddListener(Accept);
        licenseView.ExitGame.onClick.AddListener(ExitGame);
        SetText();
    }

    public void Init()
    {
    }

    private void ExitGame() 
    {
        Application.Quit();
        Debug.Log("Типо выход");
    }

    private void Accept() => _licenseView.licensePanel.SetActive(false);
    public void SetActivePanel() => _licenseView.licensePanel.SetActive(true);
    private void SetText()
    {
        _licenseView.Body.text = "";
        _licenseView.MineHead.text = _licenseView.SOLicenseAgreement.MineHeadText;
        foreach (var Paragraph in _licenseView.SOLicenseAgreement.Paragraph)
        {
            _licenseView.Body.text += Paragraph.HeadText+"\n";
            _licenseView.Body.text += Paragraph.BodyText + "\n\n";
        }
    }

}
