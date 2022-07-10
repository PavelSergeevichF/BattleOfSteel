using UnityEngine;
using UnityEngine.UI;

public class ButtonController
{
    private ButtonView buttonView;
    private GameObject buttonFire;
    private GameObject buttonMGunFire;
    private GameObject buttonMenu;
    public ButtonController(ButtonView buttonView,  GameObject buttonFire, GameObject buttonMGunFire, GameObject buttonMenu)
    {
        this.buttonView = buttonView;
        this.buttonFire = buttonFire;
        this.buttonMGunFire = buttonMGunFire;
        this.buttonMenu = buttonMenu;
    }

}
