using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public UIController ui;
    public PlayerController player;
	public AudioManager audioManager;

    private bool isGameStart;

	private void Start()
	{
		isGameStart = false;
		resetGame();
	}

	public bool IsGameStart() => isGameStart;
	
	public void PlayerWin(bool isWin)
	{
		isGameStart = false;

		if(isWin)
		{
			audioManager.PlayWin();
			ui.PlayerWin();
		}
		else
		{
			audioManager.PlayDeath();
			ui.PlayerLose();
		}
	}

	public void GameStart()
	{
		isGameStart = true;
		audioManager.PlayClick();
	}

	internal void resetGame()
	{
		audioManager.PlayClick();
		player.ResetPlayer();
	}
}
