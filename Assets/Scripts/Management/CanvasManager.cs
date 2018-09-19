using System.Collections;
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

	private Coroutine m_coroutine;

	private void Update()
	{
		m_inventoryText.text = $"{m_items.Items.Count}/{m_items.Slots}";
	}

	public void OnScreenMessage(string message)
	{
		if (m_coroutine != null) { StopCoroutine(m_coroutine); }

		m_screenMessage.text = message;
		m_screenMessage.color = m_screenMessage.color.WithAlpha(1.0f);
		m_coroutine = StartCoroutine(FadeText());
	}

	private void Awake()
	{
		m_screenMessage.color = m_screenMessage.color.WithAlpha(0.0f);
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
}