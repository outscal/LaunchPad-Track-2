using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameManager gameManager;

	public Vector2 InitalPosition;
    public float moveSpeed;
	private Vector2 moveDirection;

	public List<AudioClip> runClips;
	public AudioSource source;
	private bool isPlaying;

	private Rigidbody2D rb;

	private void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		InitalPosition = transform.position;
		isPlaying = false;
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
		{
			MovePlayer();
			PlayMoveAudio();
		}
	}

	private void PlayMoveAudio()
	{
		if (moveDirection == Vector2.zero || isPlaying)
			return;
		source.clip = runClips[Random.Range(0,runClips.Count)];
		source.Play();
		StartCoroutine(RunningAudio());
	}

	IEnumerator RunningAudio()
	{
		isPlaying = true;
		yield return new WaitForSeconds(0.25f);
		isPlaying = false;
	}

	private void MovePlayer()
	{
		rb.MovePosition((Vector2)transform.position + (moveDirection * moveSpeed * Time.fixedDeltaTime));
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (!gameManager.IsGameStart())
			return;

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
