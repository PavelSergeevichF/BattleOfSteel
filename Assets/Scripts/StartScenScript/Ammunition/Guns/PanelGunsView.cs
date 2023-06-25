using UnityEngine.UI;
using UnityEngine;

public class PanelGunsView : AmmunitionsElement
{
    [Header("Buttons")]
    [SerializeField] private Button _gunSelect;
    [SerializeField] private Button _machinGunSelect;

    [Header("Panels")]
    [SerializeField] private GameObject _gunRawImage;
    [SerializeField] private GameObject _machinGunRawImage;
    [SerializeField] private GameObject _imageGun1;
    [SerializeField] private GameObject _imageGun2;
    [SerializeField] private GameObject _imageGun3;
    [SerializeField] private GameObject _imageMachinGun1;
    [SerializeField] private GameObject _imageMachinGun2;

    [Header("Slider")]
    public Slider CaliberSlider;
    public Slider LongSlider;
    public Slider SpeedSlider;

    [Header("Text")]
    public Text CaliberText;
    public Text LongText;
    public Text SpeedText;

    public Button GunSelect => _gunSelect;
    public Button MachinGunSelect => _machinGunSelect;

    public GameObject GunRawImage => _gunRawImage;
    public GameObject MachinGunRawImage => _machinGunRawImage;
    public GameObject ImageGun1 => _imageGun1;
    public GameObject ImageGun2 => _imageGun2;
    public GameObject ImageGun3 => _imageGun3;
    public GameObject ImageMachinGun1 => _imageMachinGun1;
    public GameObject ImageMachinGun2 => _imageMachinGun2; // PanelAmmunitionView
}