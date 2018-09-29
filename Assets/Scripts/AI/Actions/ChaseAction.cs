using UnityEngine;

[CreateAssetMenu(menuName = "AI/Actions/Chase")]
public class ChaseAction : Action
{
	[SerializeField]
	private float m_chaseSpeedMultiplier = 2.0f;

	public override void Enter(StateController controller)
	{
		controller.Owner.Agent.speed *= m_chaseSpeedMultiplier;
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
		controller.Owner.Agent.speed /= m_chaseSpeedMultiplier;
	}

	private void Chase(StateController controller)
	{
		if (controller.Owner.Detection() != null)
		{
			controller.Owner.Agent.SetDestination(controller.Owner.Detection().transform.position);
		}
	}
}