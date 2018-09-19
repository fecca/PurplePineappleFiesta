using System.Collections.Generic;
using System.Linq;

public class Inventory
{
	private HashSet<Item> m_items = new HashSet<Item>();

	public bool AddItem(Item item)
	{
		if (m_items.Count >= 10)
		{
			return false;
		}

		m_items.Add(item);

		return true;
	}

	public bool GetItem(Item item)
	{
		if (!m_items.Contains(item))
		{
			return false;
		}

		m_items.Remove(item);

		return true;
	}

	public Item Pop()
	{
		if (m_items != null && m_items.Count > 0)
		{
			var item = m_items.FirstOrDefault();
			if (item != null)
			{
				m_items.Remove(item);

				return item;
			}
		}

		return null;
	}
}
