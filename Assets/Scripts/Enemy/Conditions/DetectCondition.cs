using UnityEngine;

[CreateAssetMenu(menuName = "AI/Conditions/Detect")]
public class DetectCondition : Condition
{
	public override bool CheckCondition(StateController controller)
	{
		var hasDetected = controller.Owner.DetectedObject() != null;

		return hasDetected;
	}
}