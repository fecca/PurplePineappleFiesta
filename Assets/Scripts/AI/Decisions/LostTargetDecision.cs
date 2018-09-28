using UnityEngine;

[CreateAssetMenu(menuName = "AI/Decisions/LostTarget")]
public class LostTargetDecision : Decision
{
	public override bool Decide(StateController controller)
	{
		var isTargetTooFarAway = IsTargetTooFarAway(controller);

		return isTargetTooFarAway;
	}

	private bool IsTargetTooFarAway(StateController controller)
	{
		return controller.Owner.Detection() == null;
	}
}