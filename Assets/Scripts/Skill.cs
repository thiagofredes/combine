using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour {

	public event System.Action SkillEnd;

	public ParticleSystem particles;

	public float damage;

	public SkillEffect effect;	

	private List<ParticleCollisionEvent> collisionEvents;

	private bool _usingSkill;

	private bool _allowCollisions;

	void Awake(){
		collisionEvents = new List<ParticleCollisionEvent>();
		_usingSkill = false;
	}

	public void Use(){
		if(!_usingSkill){
			_usingSkill = true;
			particles.Play();
			_allowCollisions = true;
		}
	}

	public bool CanCauseDamage()
    {
        return _allowCollisions;
    }

	void OnParticleSystemStopped(){
		_allowCollisions = false;
		_usingSkill = false;
		if(SkillEnd != null)
			SkillEnd();
	}
}
