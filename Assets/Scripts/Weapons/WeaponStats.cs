using UnityEngine;

[CreateAssetMenu(menuName = "Weapons/Stats", order = 0)]
public class WeaponStats : ScriptableObject
{
	public int Bullets;
	public float Spread;
	public float FollowSpeed;
	public LineRenderer LineRenderer;
}