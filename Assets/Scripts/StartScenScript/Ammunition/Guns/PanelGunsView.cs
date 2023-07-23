using UnityEngine.UI;
using UnityEngine;

public class PanelGunsView : AmmunitionsElement
{
    [Header("Buttons")]
    [SerializeField] private Button _gunSelect;
    [SerializeField] private Button _machinGunSelect;
    [SerializeField] private Button _select;

    [Header("Panels")]
    [SerializeField] private GameObject _gunRawImage;
    [SerializeField] private GameObject _machinGunRawImage;

    [Header("Slider")]
    public Slider CaliberSlider;
    public Slider LongSlider;
    public Slider SpeedSlider;

    [Header("Text")]
    public Text CaliberText;
    public Text LongText;
    public Text SpeedText;

    [Header("Gun barrel")]
    [SerializeField] private GameObject _gunBarrel;
    [SerializeField] private GameObject _machinGunBarrel;

    public Button GunSelect => _gunSelect;
    public Button MachinGunSelect => _machinGunSelect;
    public Button Select => _select;

    public GameObject GunRawImage => _gunRawImage;
    public GameObject MachinGunRawImage => _machinGunRawImage;

    public GameObject GunBarrel => _gunBarrel;
    public GameObject MachinGunBarrel => _machinGunBarrel;
}
