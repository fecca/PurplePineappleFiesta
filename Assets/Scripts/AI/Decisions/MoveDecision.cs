using UnityEngine;

[CreateAssetMenu(menuName = "AI/Decisions/Move")]
public class MoveDecision : Decision
{
	public override bool Decide(StateController controller)
	{
		var value = CanMove(controller);

		return value;
	}

	private bool CanMove(StateController controller)
	{
		return !controller.Owner.Agent.IsMoving();
	}
}