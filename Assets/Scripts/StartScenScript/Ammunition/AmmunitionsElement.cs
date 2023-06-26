using UnityEngine.UI;
using UnityEngine;

public class AmmunitionsElement : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] private Button _information;

    [Header("Scripts")]
    [SerializeField] private PraceView _praceView;

    public PraceView PraceView => _praceView;
    public Button Information => _information;
}