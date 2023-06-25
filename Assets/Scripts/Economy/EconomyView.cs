using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EconomyView : MonoBehaviour
{
    [SerializeField] private Text _goldText;
    [SerializeField] private Text _silverText;
    [SerializeField] private Text _copperText;
    [SerializeField] private Text _expText;

    [SerializeField] private Text _goldTextErr;
    [SerializeField] private Text _silverTextErr;
    [SerializeField] private Text _copperTextErr;
    [SerializeField] private Text _expTextErr;

    [SerializeField] private SOUserData _sOUserData;
    private EconomyController _economyController;

    private void Awake()
    {
        _economyController = new EconomyController
            (
            _goldText,
            _silverText,
            _copperText,
            _expText,
           _goldTextErr,
           _silverTextErr,
           _copperTextErr,
           _expTextErr,
           _sOUserData
            );
    }

    private void Update() => _economyController.Update();
}
