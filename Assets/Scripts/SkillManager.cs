using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour {

	public event System.Action SkillEnded;

	public Skill[] skills;

	private int _currentSkill = 0;

	void OnEnable(){
		foreach(Skill s in skills){
			s.SkillEnd += OnSkillEnd;
		}
	}

	void OnDisable(){
		foreach(Skill s in skills){
			s.SkillEnd -= OnSkillEnd;
		}
	}

	public void UseSkill(){
		if(_currentSkill != -1){
			skills[_currentSkill].Use();
			// _currentSkill = -1;
		}
	}

	public void OnSkillEnd(){
		if(SkillEnded != null)
			SkillEnded();
	}
}
