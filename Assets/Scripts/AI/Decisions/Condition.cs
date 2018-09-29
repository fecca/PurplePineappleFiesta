﻿using UnityEngine;

public abstract class Condition : ScriptableObject
{
	public abstract bool CheckCondition(StateController controller);
}
