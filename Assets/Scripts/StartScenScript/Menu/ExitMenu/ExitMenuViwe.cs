using UnityEngine.UI;
using UnityEngine;

public class ExitMenuViwe : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] private Button _back;
    [SerializeField] private Button _exit;

    [Header("Panels")]
    [SerializeField] private GameObject _exitPanel;

    public Button Back => _back;
    public Button Exit => _exit;

    public GameObject ExitPanel => _exitPanel;

    private void Awake()
    {
        ExitMenuController exitMenuController = new ExitMenuController(this);
    }
}
