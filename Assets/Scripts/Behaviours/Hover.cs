using UnityEngine;

public class Hover : MonoBehaviour
{
	[SerializeField]
	private FloatReference Strength;

	private float m_originalY;
	private float m_timer;

	private void Awake()
	{
		m_originalY = transform.position.y;
	}

	private void OnEnable()
	{
		transform.position = transform.position.WithY(m_originalY);
	}

	private void Update()
	{
		m_timer += Time.deltaTime;
		transform.position = new Vector3(transform.position.x, m_originalY + (Mathf.Sin(m_timer) * Strength.Value), transform.position.z);
	}
}