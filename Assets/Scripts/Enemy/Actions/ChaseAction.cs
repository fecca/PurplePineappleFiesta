using UnityEngine;

[CreateAssetMenu(menuName = "AI/Actions/Chase")]
public class ChaseAction : Action
{
	public override void Enter(StateController controller)
	{
		controller.Owner.SetChaseSpeed();
		Chase(controller);
	}

	public override void Execute(StateController controller)
	{
		if (controller.CheckTimer(1.0f))
		{
			Chase(controller);
		}
	}

	public override void Exit(StateController controller)
	{
		controller.Owner.SetMovementSpeed();
	}

	private void Chase(StateController controller)
	{
		if (controller.Owner.DetectedObject() != null)
		{
			controller.Owner.Agent.SetDestination(controller.Owner.DetectedObject().transform.position);
		}
	}
}