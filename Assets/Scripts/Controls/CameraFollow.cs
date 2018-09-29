using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	[Header("Position")]
	[SerializeField]
	private Transform m_parent;
	[SerializeField]
	private FloatReference m_followSpeed;

	[Header("Rotation")]
	[SerializeField]
	private bool m_rotate;
	[SerializeField]
	private FloatReference m_rotationSpeed;

	private void Update()
	{
		transform.position = Vector3.Lerp(transform.position, m_parent.position, Time.deltaTime * m_followSpeed.Value);

		if (m_rotate)
		{
			if (Input.GetMouseButton(2))
			{
				var mouseX = Input.GetAxis("Mouse X");
				transform.RotateAround(m_parent.position, Vector3.up, mouseX * Time.deltaTime * m_rotationSpeed.Value);
			}
		}
	}
}