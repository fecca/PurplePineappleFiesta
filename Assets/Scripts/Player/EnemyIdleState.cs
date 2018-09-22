using UnityEngine;

public class EnemyIdleState : State
{
	private Enemy m_enemy;

	public EnemyIdleState(Enemy enemy)
	{
		m_enemy = enemy;
	}

	public override void Enter()
	{
		Debug.Log("EnemyIdleState.Enter");
	}

	public override void Update()
	{
	}

	public override void Exit()
	{
		Debug.Log("EnemyIdleState.Exit");
	}
}
public class EnemyTestState : State
{
	private Enemy m_enemy;

	public EnemyTestState(Enemy enemy)
	{
		m_enemy = enemy;
	}

	public override void Enter()
	{
		Debug.Log("EnemyTestState.Enter");
	}

	public override void Update()
	{
		m_enemy.MoveToRandomPositionOnNavMesh();
	}

	public override void Exit()
	{
		Debug.Log("EnemyTestState.Exit");
	}
}