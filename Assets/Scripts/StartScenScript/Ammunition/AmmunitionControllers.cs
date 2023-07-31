public class AmmunitionControllers : IAmmunitionController
{
    public ActivePanelAmmunition ActivePanelAmmunition;
    public void SetTypePanel(ActivePanelAmmunition activePanel)
    {
        ActivePanelAmmunition = activePanel;
    }
}