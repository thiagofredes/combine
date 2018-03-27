using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Running : PlayerState
{
	private Vector3 counterMovement;

	public Running (PlayerController player)
	{
		this.player = player;
	}

	public override void Update ()
	{
		if (!player.gamePaused && !player.gameEnded) {
			float horizontal = Input.GetAxis ("Horizontal");
			float vertical = Input.GetAxis ("Vertical");
			Vector3 movement = ThirdPersonCameraController.CameraForwardProjectionOnGround * vertical + ThirdPersonCameraController.CameraRightProjectionOnGround * horizontal;			

			if (movement.magnitude < 0.1f)
				player.transform.rotation = Quaternion.LookRotation (player.transform.forward);
			else
				player.transform.rotation = Quaternion.LookRotation (movement);

			if(Input.GetMouseButtonDown(0)){
				player.SetState(new Attacking(this.player));
			}
			else if(Input.GetMouseButton(1)){
				player.SetState(new UsingSkill(this.player));
			}

			player.animator.SetFloat ("Forward", movement.normalized.magnitude);
			player.characterController.Move (player.movementSpeed * Time.deltaTime * (movement.normalized + counterMovement.normalized));
		}
	}

    public override void LateUpdate()
    {
        player.characterController.Move(counterMovement.normalized * player.movementSpeed * Time.deltaTime);
    }

	public override void OnTriggerExit (Collider other)
	{
		counterMovement = Vector3.zero;
	}

	public override void OnAnimationEvent(string ev){
		if(ev == "ReturnMovement"){
			player.SetState(new Running(this.player));
		}
	}
}
