using System;
using UnityEngine;

[Serializable]
public class Transition
{
	[SerializeField]
	private Condition m_conditions;
	[SerializeField]
	private State m_trueState;
	[SerializeField]
	private State m_falseState;

	public State TrueState { get { return m_trueState; } }
	public State FalseState { get { return m_falseState; } }

	public bool CheckCondition(StateController controller)
	{
		return m_conditions.CheckCondition(controller);
	}
}
