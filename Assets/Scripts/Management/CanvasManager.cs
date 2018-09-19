using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
	[SerializeField]
	private Text m_text;
	[SerializeField]
	private ItemRuntimeSet m_items;

	private void Update()
	{
		m_text.text = $"{m_items.Items.Count}/{m_items.Slots}";
	}
}