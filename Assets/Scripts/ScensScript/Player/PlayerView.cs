using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    [SerializeField] private GameObject _bot;
    [SerializeField] private GameObject _centrCam;

    private PlayerController _playerController;

    public Transform CentrCamTransform => _centrCam.transform;

    private void Awake()
    {
        _playerController = new PlayerController(this, _bot, _centrCam);
    }

    void Start()
    {
        
    }

    void Update()
    {
        _playerController.Update();
    }
}
