using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelEquipmentController : AmmunitionControllers
{
    private bool _firstStart = true;
    private PanelAmmunitionController _panelAmmunitionController;

    public PanelEquipmentController(PanelAmmunitionController panelAmmunitionController)
    {
        _panelAmmunitionController = panelAmmunitionController;
    }

    public void Execute()
    {
        if (ActivePanelAmmunition == ActivePanelAmmunition.Engine)
        {
            if (_firstStart)
            {
                _firstStart = false;
            }
        }
    }
}
