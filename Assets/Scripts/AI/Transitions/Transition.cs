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

	public State TrueState { get { return m_trueState; } }
	public State FalseState { get { return m_falseState; } }

	public bool Decide(StateController controller)
	{
		return m_decision.Decide(controller);
	}
}
