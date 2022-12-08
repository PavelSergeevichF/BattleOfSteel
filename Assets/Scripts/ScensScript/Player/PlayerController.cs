using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController
{
    private PlayerView _playerView;
    private GameObject _bot;
    private GameObject _centrCam;
    public PlayerController(PlayerView playerView, GameObject bot, GameObject centrCam)
    {
        _playerView = playerView;
        _bot = bot;
        _centrCam = centrCam;
    }


    public void Update()
    {
        _playerView.transform.position = _bot.transform.position;
    }
}
