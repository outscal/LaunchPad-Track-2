using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
	public GameManager gameManager;

	public GameObject MainMenuPanel;
	public GameObject GameOverPanel;
	public Text GameOverText;

	private void Start()
	{
		ShowMenu();
	}

	internal void PlayerWin()
	{
		GameOverText.text = "WIN";
		GameOverPanel.SetActive(true);
	}

	internal void PlayerLose()
	{
		GameOverText.text = "LOSE";
		GameOverPanel.SetActive(true);
	}

	public void ShowMenu()
	{
		GameOverPanel.SetActive(false);
		MainMenuPanel.SetActive(true);
	}

	public void GameStart()
	{
		MainMenuPanel.SetActive(false);
		gameManager.GameStart();
	}

	public void ExitGame()
	{
		Application.Quit();
	}
}
