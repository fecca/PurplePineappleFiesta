using UnityEngine;

[CreateAssetMenu(menuName = "AI/Decisions/Detect")]
public class DetectDecision : Decision
{
	public override bool Decide(StateController controller)
	{
		var value = Detect(controller);

		return value;
	}

	private bool Detect(StateController controller)
	{
		return controller.Owner.Detection() != null;
	}
}