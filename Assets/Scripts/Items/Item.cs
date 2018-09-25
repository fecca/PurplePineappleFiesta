using UnityEngine;

public class Item : MonoBehaviour
{
	[SerializeField]
	private ItemData Data;

	public void Init(Vector3 position, ItemData itemData)
	{
		transform.position = position;
		Data = itemData;
		transform.localScale = Vector3.one * 0.5f;
	}

	public void PickUp()
	{
		GetComponent<Hover>().enabled = false;
		GetComponent<Rotate>().enabled = false;

		transform.localScale *= 0.5f;
	}

	public void Drop()
	{
		GetComponent<Hover>().enabled = true;
		GetComponent<Rotate>().enabled = true;

		transform.localScale *= 2.0f;
	}
}
