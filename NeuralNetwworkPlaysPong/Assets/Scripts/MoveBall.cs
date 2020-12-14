using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MoveBall : MonoBehaviour
{

	private Vector3 ballStarPosition;
	private Rigidbody2D _rigidbody;
	private float _speed = 400;

	public AudioSource blip;
	public AudioSource blop;

	private void Start()
	{
		_rigidbody = GetComponent<Rigidbody2D>();
		ballStarPosition = transform.position;
		ResetBall();
	}

	private void Update()
	{
		if (Input.GetKeyDown("space"))
		{
			ResetBall();
		}
	}

	private void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "backwall")
		{
			blop.Play();
		}
		else
		{
			blip.Play();
		}
	}

	public void ResetBall()
	{
		transform.position = ballStarPosition;
		_rigidbody.velocity = Vector3.zero;
		Vector3 dir = new Vector3(Random.Range(100,300), Random.Range(-100,100), 0).normalized;
		_rigidbody.AddForce(dir*_speed);
	}
	
	
}
