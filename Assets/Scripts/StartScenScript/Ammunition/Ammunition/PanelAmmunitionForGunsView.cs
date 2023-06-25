using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;

public class PanelAmmunitionForGunsView : AmmunitionsElement
{
    [Header("Buttons")]
    [SerializeField] private Button _shellSelect;
    [SerializeField] private Button _bulletSelect;
    [SerializeField] private Button _nextSelect;
    [SerializeField] private Button _beckSelect;

    [Header("Slider")]
    public Slider NumSlider;

    [Header("PanelsShell")]
    [SerializeField] private List<GameObject> _shells;

    [Header("PanelsBullet")]
    [SerializeField] private List<GameObject> _bullets;

    public Button ShellSelect => _shellSelect;
    public Button BulletSelect => _bulletSelect;
    public Button NextSelect => _nextSelect;
    public Button BeckSelect => _beckSelect;

    public List<GameObject> Shells => _shells;

    public List<GameObject> Bullets => _bullets;
}