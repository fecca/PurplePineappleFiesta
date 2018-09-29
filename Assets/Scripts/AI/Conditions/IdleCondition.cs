using UnityEngine;

[CreateAssetMenu(menuName = "AI/Conditions/Idle")]
public class IdleCondition : Condition
{
	public override bool CheckCondition(StateController controller)
	{
		var canMove = !controller.Owner.Agent.IsMoving();

		return canMove;
	}
}