using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	[SerializeField]
	private Transform m_parent;
	[SerializeField]
	private float m_followSpeed;

	private void Update()
	{
		transform.position = Vector3.Lerp(transform.position, m_parent.position, Time.deltaTime * m_followSpeed);
	}
}