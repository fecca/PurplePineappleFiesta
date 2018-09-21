using UnityEngine;

[CreateAssetMenu(menuName = "Weapons/Stats", order = 0)]
public class WeaponStats : ScriptableObject
{
	[Header("Shooting")]
	public int Bullets;
	public float SpreadRadius;
	public float Distance;
	public float Cooldown;

	[Header("Movement")]
	public float FollowSpeed;
	public int Frames;

	[Header("Rendering")]
	public LineRenderer LineRenderer;
	public float LineRendererDuration;
}