using UnityEngine;

[CreateAssetMenu(menuName = "Enemy/Stats")]
public class EnemyStats : ScriptableObject
{
	[Header("Movement")]
	public float MovementSpeed = 2.0f;
	public float ChaseSpeed = 10.0f;
	public float PatrolRadius = 5.0f;

	[Header("Health")]
	public float BaseHealth = 10.0f;

	[Header("Loot")]
	public LootTable LootTable;
}