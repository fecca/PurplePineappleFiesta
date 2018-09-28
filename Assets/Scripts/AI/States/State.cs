using UnityEngine;

[CreateAssetMenu(menuName = "AI/State")]
public class State : ScriptableObject
{
	[SerializeField]
	private Action[] m_actions;
	[SerializeField]
	private Transition[] m_transitions;

	public void Enter(StateController controller)
	{
		foreach (var action in m_actions)
		{
			action.Enter(controller);
		}
	}

	public void Execute(StateController controller)
	{
		foreach (var action in m_actions)
		{
			action.Execute(controller);
		}

		CheckTransitions(controller);
	}

	public void Exit(StateController controller)
	{
		foreach (var action in m_actions)
		{
			action.Exit(controller);
		}
	}

	private void CheckTransitions(StateController controller)
	{
		State trueState = null;
		State falseState = null;

		foreach (var transition in m_transitions)
		{
			var decision = transition.Decide(controller);
			if (decision && trueState == null)
			{
				trueState = transition.TrueState;
			}
			else if (falseState == null)
			{
				falseState = transition.FalseState;
			}
		}

		if (trueState != null)
		{
			controller.TransitionToState(trueState);
		}
		else
		{
			controller.TransitionToState(falseState);
		}
	}
}
