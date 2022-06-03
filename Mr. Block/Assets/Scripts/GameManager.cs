using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public UIController ui;
    public PlayerController player;

    private bool isGameStart;

	private void Start()
	{
		isGameStart = false;
	}

	public bool IsGameStart() => isGameStart;
	
	public void PlayerWin(bool isWin)
	{
		isGameStart = false;

		if(isWin)
		{
			ui.PlayerWin();
		}
		else
		{
			ui.PlayerLose();
		}
	}

	public void GameStart()
	{
		isGameStart = true;
		player.ResetPlayer();
	}
}
