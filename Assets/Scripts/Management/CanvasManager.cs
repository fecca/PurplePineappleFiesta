using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
	[SerializeField]
	private Text m_screenMessage;
	[SerializeField]
	private Text m_inventoryText;
	[SerializeField]
	private ItemRuntimeSet m_items;
	[SerializeField]
	private Text m_itemText;
	[SerializeField]
	private GameObject m_inventory;
	[SerializeField]
	private GameObject m_inventoryItem;

	private Coroutine m_coroutine;
	private Dictionary<Item, Text> m_itemTexts = new Dictionary<Item, Text>();

	private void Awake()
	{
		m_screenMessage.color = m_screenMessage.color.WithAlpha(0.0f);
	}

	private void Update()
	{
		foreach (var itemText in m_itemTexts)
		{
			var screenPosition = Camera.main.WorldToScreenPoint(itemText.Key.transform.position + Vector3.up);
			itemText.Value.rectTransform.position = screenPosition;
		}
	}

	private IEnumerator FadeText()
	{
		yield return new WaitForSeconds(1.0f);

		var startingAlpha = m_screenMessage.color.a;
		var endingAlpha = 0.0f;
		var currentAlpha = startingAlpha;
		var t = 0.0f;
		var overTime = 0.25f;

		while (currentAlpha > endingAlpha)
		{
			currentAlpha = Mathf.Lerp(startingAlpha, endingAlpha, t / overTime);
			m_screenMessage.color = m_screenMessage.color.WithAlpha(currentAlpha);
			t += Time.deltaTime;

			yield return new WaitForEndOfFrame();
		}
	}

	private void ToggleInventory()
	{
		m_inventory.SetActive(!m_inventory.activeInHierarchy);
	}

	public void OnScreenMessage(string message)
	{
		if (m_coroutine != null) { StopCoroutine(m_coroutine); }

		m_screenMessage.text = message;
		m_screenMessage.color = m_screenMessage.color.WithAlpha(1.0f);
		m_coroutine = StartCoroutine(FadeText());
	}

	public void OnItemSpawned(Item item)
	{
		var newText = Instantiate(m_itemText, transform);
		newText.text = item.gameObject.name;
		m_itemTexts.Add(item, newText);
	}

	public void OnItemPickedUp(Item item)
	{
		if (m_itemTexts.ContainsKey(item))
		{
			Destroy(m_itemTexts[item].gameObject);
			m_itemTexts.Remove(item);
		}

		m_inventoryText.text = string.Format("{0}/{1}", m_items.Items.Count, m_items.Slots);

		Instantiate(m_inventoryItem, m_inventory.transform);
	}

	public void OnInventoryBindingPressed()
	{
		ToggleInventory();
	}
}