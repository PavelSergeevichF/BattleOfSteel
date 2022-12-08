using UnityEngine;
using UnityEngine.UI;

public class ButtonController
{
    private ButtonView _buttonView;
    private GameObject _buttonMenu;
    public ButtonController(ButtonView buttonView, GameObject buttonMenu)
    {
        _buttonView = buttonView;
        _buttonMenu = buttonMenu;
    }

}
