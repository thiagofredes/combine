﻿using UnityEngine;

public class PlayerState
{
	protected PlayerController player;

	public virtual void OnEnter ()
	{
	}

	public virtual void OnExit ()
	{
	}

	public virtual void Update ()
	{
	}

	public virtual void LateUpdate ()
	{
	}

	public virtual void OnTriggerEnter (Collider other)
	{
		
	}

	public virtual void OnTriggerExit (Collider other)
	{

	}

	public virtual void OnAnimationEvent(string ev){

	}
}
