using UnityEngine;

[CreateAssetMenu(menuName = "Weapons/Stats")]
public class WeaponStats : ScriptableObject
{
	[Header("Shooting")]
	public int Bullets = 5;
	public float SpreadRadius = 1.0f;
	public float Distance = 10.0f;
	public float Cooldown = 0.5f;
	public float Damage = 5.0f;

	[Header("Movement")]
	public float FollowSpeed = 20.0f;
	public int ShootAnimationFrames = 10;

	[Header("Rendering")]
	public LineRenderer LineRenderer;
	public float LineRendererDuration;
}