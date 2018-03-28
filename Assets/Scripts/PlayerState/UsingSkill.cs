using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsingSkill : PlayerState {

	public UsingSkill(PlayerController player){
		this.player = player;
	}

	public override void OnEnter(){
		player.animator.SetTrigger("Skill");		
	}

	public override void LateUpdate(){
		player.mouth.transform.LookAt(player.transform.position + player.transform.forward);
	}

	public override void OnAnimationEvent(string ev){
		if(ev == "ReturnMovement"){
			player.SetState(new Running(this.player));
		}
	}
}
