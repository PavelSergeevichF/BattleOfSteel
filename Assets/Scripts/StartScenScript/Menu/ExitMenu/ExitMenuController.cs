using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitMenuController
{
    private ExitMenuViwe _exitMenuViwe;

    public ExitMenuController(ExitMenuViwe exitMenuViwe)
    {
        _exitMenuViwe = exitMenuViwe;
        exitMenuViwe.Back.onClick.AddListener(ClickOnBack);
        exitMenuViwe.Exit.onClick.AddListener(ClickOnExit);
    }                 

    private void ClickOnBack()
    {
        _exitMenuViwe.ExitPanel.SetActive(false);
    }
    private void ClickOnExit()
    {
        Application.Quit();
        Debug.Log("Типо выход");
    }
}
