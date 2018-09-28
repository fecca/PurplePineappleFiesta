using System;
using UnityEngine;

[Serializable]
public class Transition
{
	[SerializeField]
	private Decision m_decision;
	[SerializeField]
	private State m_trueState;
	[SerializeField]
	private State m_falseState;

	public State GetDecisionState(StateController controller)
	{
		if (m_decision.Decide(controller))
		{
			return m_trueState;
		}
		else
		{
			return m_falseState;
		}
	}
}
