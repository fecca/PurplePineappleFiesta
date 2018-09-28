using UnityEngine;

[CreateAssetMenu(menuName = "AI/State")]
public class State : ScriptableObject
{
	[SerializeField]
	private Action[] m_actions;
	[SerializeField]
	private Transition[] m_transitions;

	public void Execute(StateController controller)
	{
		Act(controller);
		CheckTranstitions(controller);
	}

	private void Act(StateController controller)
	{
		foreach (var action in m_actions)
		{
			action.Act(controller);
		}
	}

	private void CheckTranstitions(StateController controller)
	{
		foreach (var transition in m_transitions)
		{
			var newState = transition.GetDecisionState(controller);
			controller.TransitionToState(newState);
		}
	}
}
