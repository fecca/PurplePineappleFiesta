using UnityEngine;

public class HitBox : MonoBehaviour
{
	[SerializeField]
	private Enemy m_enemy;

	public void OnHit(float damage)
	{
		m_enemy.OnHit(damage);
	}
}