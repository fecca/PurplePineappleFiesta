using UnityEngine;

[CreateAssetMenu(menuName = "AI/Actions/Chase")]
public class ChaseAction : Action
{
	public override void Act(StateController controller)
	{
		if (controller.Owner.Detection() != null)
		{
			Move(controller);
		}
	}

	private void Move(StateController controller)
	{
		controller.Owner.Agent.SetDestination(controller.Owner.Detection().transform.position);
	}
}