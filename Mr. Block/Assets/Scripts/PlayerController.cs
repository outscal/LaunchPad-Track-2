using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameManager gameManager;

	public Vector2 InitalPosition;
    public float moveSpeed;
	private Vector2 moveDirection;

	private Rigidbody2D rb;

	private void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		InitalPosition = transform.position;
	}

	public void ResetPlayer()
	{
		transform.position = InitalPosition;
	}

	private void Update()
	{
		GetInput();
	}

	private void GetInput()
	{
		moveDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
	}

	private void FixedUpdate()
	{
		if (gameManager.IsGameStart())
			MovePlayer();
	}

	private void MovePlayer()
	{
		rb.MovePosition((Vector2)transform.position + (moveDirection * moveSpeed * Time.fixedDeltaTime));
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.CompareTag("Wall"))
		{
			gameManager.PlayerWin(false);
		}
		else if(collision.gameObject.CompareTag("Goal"))
		{
			gameManager.PlayerWin(true);
		}
	}
}
