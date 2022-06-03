using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class UIController : MonoBehaviour
{
	public GameManager gameManager;
	public CameraController cam;

	public GameObject MainMenuPanel;
	public GameObject GameOverPanel;
	public Text GameOverText;

	private void Start()
	{
		ShowMenu();
	}

	public void PlayerWin()
	{
		GameOverText.text = "WIN";
		gameOverPanelReveal();
	}

	public void PlayerLose()
	{
		GameOverText.text = "LOSE";
		gameOverPanelReveal();
	}

	public void gameOverPanelReveal()
	{
		StartCoroutine(CameraShake());
	}
	
	IEnumerator CameraShake()
	{
		cam.CameraShake(true);
		yield return new WaitForSeconds(2f);
		GameOverPanel.SetActive(true);
		cam.CameraShake(false);
	}

	public void ShowMenu()
	{
		GameOverPanel.SetActive(false);
		MainMenuPanel.SetActive(true);
		gameManager.resetGame();
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
