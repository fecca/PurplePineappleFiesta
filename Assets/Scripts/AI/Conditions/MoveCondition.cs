using UnityEngine;

[CreateAssetMenu(menuName = "AI/Conditions/Move")]
public class MoveCondition : Condition
{
	public override bool CheckCondition(StateController controller)
	{
		var canMove = !controller.Owner.Agent.IsMoving();
		var timerHasElapsed = controller.CheckTimer(2.0f);

		return canMove && timerHasElapsed;
	}
}