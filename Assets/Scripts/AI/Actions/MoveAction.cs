using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "AI/Actions/Move")]
public class MoveAction : Action
{
	public override void Act(StateController controller)
	{
		if (!controller.Owner.Agent.IsMoving())
		{
			Move(controller);
		}
	}

	private void Move(StateController controller)
	{
		var patrolRadius = 5.0f;
		var randomDirection = Random.insideUnitSphere * patrolRadius;
		randomDirection += controller.Owner.Agent.transform.position;
		NavMeshHit hit;
		var finalPosition = Vector3.zero;
		if (NavMesh.SamplePosition(randomDirection, out hit, patrolRadius, 1))
		{
			finalPosition = hit.position;
		}

		controller.Owner.Agent.SetDestination(finalPosition);
	}
}