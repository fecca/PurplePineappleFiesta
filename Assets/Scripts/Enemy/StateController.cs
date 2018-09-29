using UnityEngine;

public class StateController : MonoBehaviour
{
	[SerializeField]
	private Enemy m_enemy;
	[SerializeField]
	private State m_startState;

	public Enemy Owner { get { return m_enemy; } }

	private State m_currentState;
	private float m_timer;

	private void Awake()
	{
		m_currentState = m_startState;
	}

	private void Update()
	{
		m_currentState.Execute(this);
	}

	public void TransitionToState(State newState)
	{
		if (newState == null || newState == m_currentState)
		{
			return;
		}

		m_timer = 0f;
		m_currentState.Exit(this);
		m_currentState = newState;
		m_currentState.Enter(this);
	}

	public bool CheckTimer(float time)
	{
		m_timer += Time.deltaTime;

		if (m_timer >= time)
		{
			m_timer = 0f;
			return true;
		}

		return false;
	}
}