using UnityEngine;
using UnityEngine.UI;

public class ButtonView : MonoBehaviour
{
    public SOBotConnect Bot;
    [SerializeField] private GameObject _buttonMenu;
    private ButtonFireController _buttonFireController;
    private ButtonController _buttonController;

    

    void Start()
    {        
        _buttonController = new ButtonController(this, _buttonMenu);
        _buttonFireController = new ButtonFireController(Bot);
        Debug.Log("++");
    }
    private void Update() 
    { 
        _buttonFireController.Update();
    }
    
    public void GunFire() => _buttonFireController.GunFire();
    public void MachineGunFire() => _buttonFireController.MachineGunFire();
    
}
