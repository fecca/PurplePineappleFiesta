using UnityEngine;

[CreateAssetMenu(menuName = "AI/Conditions/LostTarget")]
public class LostTargetCondition : Condition
{
	public override bool CheckCondition(StateController controller)
	{
		var lostTarget = controller.Owner.DetectedObject() == null;

		return lostTarget;
	}
}