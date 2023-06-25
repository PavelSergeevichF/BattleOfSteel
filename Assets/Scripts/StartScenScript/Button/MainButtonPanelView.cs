using UnityEngine;
using UnityEngine.UI;

public class MainButtonPanelView : MonoBehaviour
{
    [SerializeField] private Button _mineMenuButton;
    [SerializeField] private Button _parametrMenuButton;
    [SerializeField] private Button _hangarButton;

    [SerializeField] private GameObject _mineMenuPanel;
    [SerializeField] private GameObject _parametrPanel;
    [SerializeField] private GameObject _hangarPanel;


    public Button     MineMenuButton     => _mineMenuButton;
    public Button     ParametrMenuButton => _parametrMenuButton;
    public Button     HangarButton => _hangarButton;

    public GameObject MineMenuPanel      => _mineMenuPanel;
    public GameObject ParametrPanel      => _parametrPanel;
    public GameObject HangarPanel        => _hangarPanel;
}
