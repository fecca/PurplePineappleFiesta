using UnityEngine;

public class Weapon : MonoBehaviour
{
	[SerializeField]
	private GameObject m_bullet;
	[SerializeField]
	private Transform m_barrel;
	[SerializeField]
	private int m_bullets;
	[SerializeField]
	private float m_power;

	public void Shoot()
	{
		for (var i = 0; i < m_bullets; i++)
		{
			var bullet = Instantiate(m_bullet);
			bullet.transform.position = m_barrel.position;
			var rigidbody = bullet.GetOrAddComponent<Rigidbody>();
			var direction = m_barrel.forward + (Vector3.right * (Random.value - 0.5f)) + (Vector3.up * (Random.value - 0.5f));
			rigidbody.AddForce(direction * m_power);

			Destroy(bullet, 5.0f);
		}
	}
}
