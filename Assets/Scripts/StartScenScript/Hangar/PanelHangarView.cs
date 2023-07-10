using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;

public class PanelHangarView : MonoBehaviour
{
    [Header("ButtonsTop")]
    [SerializeField] private Button _type1;
    [SerializeField] private Button _type2;
    [SerializeField] private Button _type3;
    [SerializeField] private Button _type4;

    [Header("ButtonsDown")]
    [SerializeField] private Button _backBot;
    [SerializeField] private Button _nextBot;
    [SerializeField] private Button _selectStoreOrHangar;
    [SerializeField] private Button _back;

    [SerializeField] private Button _select;

    [Header("Text")]
    public List<Text> TextInfo;

    [Header("Panels")]
    [SerializeField] private GameObject _armorPanel;
    [SerializeField] private List<GameObject> _typePanels;

    public Button Type1 => _type1;
    public Button Type2 => _type2;
    public Button Type3 => _type3;
    public Button Type4 => _type4;
    public Button BackBot => _backBot;
    public Button NextBot => _nextBot;
    public Button SelectStoreOrHangar => _selectStoreOrHangar;
    public Button Select => _select;
    public Button Back => _back;

    public GameObject ArmorPanel => _armorPanel;

    public List<GameObject> TypePanels => _typePanels;
}
