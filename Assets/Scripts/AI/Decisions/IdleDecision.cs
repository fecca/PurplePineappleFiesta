using UnityEngine;

[CreateAssetMenu(menuName = "AI/Decisions/Idle")]
public class IdleDecision : Decision
{
	public override bool Decide(StateController controller)
	{
		var canMove = CanMove(controller);

		return canMove;
	}

	private bool CanMove(StateController controller)
	{
		return !controller.Owner.Agent.IsMoving();
	}
}