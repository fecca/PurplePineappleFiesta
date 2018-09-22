public class StateMachine<T>
{
	private State m_curretState;

	public void Initialize(State startingState)
	{
		m_curretState = startingState;
		m_curretState.Enter();
	}

	public void ChangeState(State newState)
	{
		m_curretState.Exit();
		m_curretState = newState;
		m_curretState.Enter();
	}

	public void Update()
	{
		m_curretState.Update();
	}
}
