using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacking : PlayerState {

	public Attacking(PlayerController player){
		this.player = player;
	}

	public override void OnEnter ()
	{
		this.player.animator.SetTrigger("Attack");
	}

	public override void OnAnimationEvent(string ev){
		if(ev == "ReturnMovement"){
			player.SetState(new Running(this.player));
		}
	}
}
