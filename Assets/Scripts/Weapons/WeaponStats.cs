using UnityEngine;

[CreateAssetMenu(menuName = "Weapons/Stats")]
public class WeaponStats : ScriptableObject
{
	[Header("Shooting")]
	public int Bullets;
	public float SpreadRadius;
	public float Distance;
	public float Cooldown;
	public float Damage;

	[Header("Movement")]
	public float FollowSpeed;
	public int Frames;

	[Header("Rendering")]
	public LineRenderer LineRenderer;
	public float LineRendererDuration;
}