﻿using UnityEngine;

[CreateAssetMenu(menuName = "AI/Actions/Idle")]
public class IdleAction : Action
{
	public override void Enter(StateController controller)
	{
		controller.Owner.Agent.ResetPath();
	}

	public override void Execute(StateController controller)
	{
	}

	public override void Exit(StateController controller)
	{
	}
}