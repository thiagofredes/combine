﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : BaseGameObject
{
	public CharacterController characterController;

	public float movementSpeed = 5f;

	public string[] layersToIgnoreWhenFalling;

	public Animator animator;

	public SkillManager mouth;

    public int life;

	private PlayerState currentState;
	

	void Start ()
	{
        life = 5;
		currentState = new Running (this);
	}

	void Update ()
	{
		currentState.Update ();
	}

	void LateUpdate ()
	{
		currentState.LateUpdate ();
	}

	public void SetState (PlayerState newState)
	{
		currentState.OnExit ();
		currentState = newState;
		currentState.OnEnter ();
	}

	public bool IsGrounded ()
	{
		RaycastHit groundHit;
		Vector3 rayOrigin = this.transform.position + characterController.center;
		float raycastDistance = this.characterController.height * 0.5f + characterController.skinWidth;
		float sphereRadius = this.characterController.radius;

		if (Physics.SphereCast (rayOrigin, sphereRadius, -Vector3.up, out groundHit, raycastDistance, ~LayerMask.GetMask (layersToIgnoreWhenFalling))) {
			this.characterController.Move (-Vector3.up * (sphereRadius + this.characterController.skinWidth));
			return true;
		}
			
		return false;
	}

	void OnTriggerEnter (Collider other)
	{
		this.currentState.OnTriggerEnter (other);
	}

	void OnTriggerExit (Collider other)
	{
		this.currentState.OnTriggerExit (other);
	}

    public void Damage(int damage)
    {
        // SET STATE TO HURTING OR SOMETHING
    }

	public void OnAnimationEvent(string ev){
		currentState.OnAnimationEvent(ev);
	}

	protected override void OnGamePaused ()
	{
		gamePaused = true;
		animator.speed = 0f;
	}

	protected override void OnGameEnded (bool success)
	{
		gameEnded = true;
		animator.speed = 0f;
	}

	protected override void OnGameResumed ()
	{
		gamePaused = false;
		animator.speed = 1f;
	}	
}
