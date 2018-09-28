using UnityEngine;

[CreateAssetMenu(menuName = "AI/Decisions/Move")]
public class MoveDecision : Decision
{
	public override bool Decide(StateController controller)
	{
		var canMove = !controller.Owner.Agent.IsMoving();
		var timerHasElapsed = controller.CheckTimer(2.0f);

		return canMove && timerHasElapsed;
	}
}