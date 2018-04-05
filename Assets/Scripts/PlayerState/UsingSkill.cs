using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsingSkill : PlayerState {

	public UsingSkill(PlayerController player){
		this.player = player;		
	}

	public override void OnEnter(){
		player.mouth.SkillEnded += OnSkillEnded;
		player.animator.SetTrigger("Skill");		
	}

	public override void OnExit(){
		player.mouth.SkillEnded -= OnSkillEnded;
	}

	public override void LateUpdate(){
		player.mouth.transform.LookAt(player.transform.position + player.transform.forward);
	}

	public override void OnAnimationEvent(string ev){
		if(ev == "StartSkill"){
			player.mouth.UseSkill();
		}
	}

	private void OnSkillEnded(){
		player.animator.SetTrigger("SkillEnded");
		player.SetState(new Running(player));
	}
}
