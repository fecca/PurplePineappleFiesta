using UnityEngine;

public abstract class Action : ScriptableObject
{
	public abstract void Enter(StateController controller);
	public abstract void Execute(StateController controller);
	public abstract void Exit(StateController controller);
}
