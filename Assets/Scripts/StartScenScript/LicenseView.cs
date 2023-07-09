using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class LicenseView : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] private Button _accept;
    [SerializeField] private Button _exitGame;

    [Header("Texts")]
    [SerializeField] private Text _mineHead;
    [SerializeField] private Text _body;


    [Header("Panels")]
    [SerializeField] private GameObject _licensePanel;

    [Header("SOData")]
    [SerializeField] private SOLicenseAgreement _sOLicenseAgreement;
    [SerializeField] private SOUserData _sOUserData;

    public Button Accept => _accept;
    public Button ExitGame => _exitGame;

    public Text MineHead => _mineHead;
    public Text Body => _body;

    public GameObject licensePanel => _licensePanel;

    public SOLicenseAgreement SOLicenseAgreement => _sOLicenseAgreement; 
    public SOUserData SOUserData => _sOUserData;
}