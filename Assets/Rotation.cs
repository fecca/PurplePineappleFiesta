using UnityEngine;

public class Rotation : MonoBehaviour
{
	[SerializeField]
	private float Speed = 0.5f;

	private float m_timer;

	private void Update()
	{
		m_timer += Time.deltaTime;
		transform.Rotate(Vector3.up, Time.deltaTime * Speed, Space.World);
	}
}