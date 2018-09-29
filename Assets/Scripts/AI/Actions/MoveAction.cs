using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "AI/Actions/Move")]
public class MoveAction : Action
{
	public override void Enter(StateController controller)
	{
	}

	public override void Execute(StateController controller)
	{
		Move(controller);
	}

	public override void Exit(StateController controller)
	{
	}

	private void Move(StateController controller)
	{
		if (!controller.Owner.Agent.IsMoving())
		{
			var randomDirection = Random.insideUnitSphere * controller.Owner.PatrolRadius;
			randomDirection += controller.Owner.Agent.transform.position;
			NavMeshHit hit;
			var finalPosition = Vector3.zero;
			if (NavMesh.SamplePosition(randomDirection, out hit, controller.Owner.PatrolRadius, 1))
			{
				finalPosition = hit.position;
			}

			controller.Owner.Agent.SetDestination(finalPosition);
		}
	}
}