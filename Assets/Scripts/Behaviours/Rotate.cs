using UnityEngine;

public class Rotate : MonoBehaviour
{
	[SerializeField]
	private FloatReference Speed;

	private float m_timer;

	private void Update()
	{
		m_timer += Time.deltaTime;
		transform.Rotate(Vector3.up, Time.deltaTime * Speed.Value, Space.World);
	}
}