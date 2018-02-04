
using UnityEngine;
using UnityEngine.Events;

namespace CtoVsBugs
{

public class OnStartTrigger : MonoBehaviour
{
	public UnityEvent Trigger;

	private void Start()
	{
		this.Trigger.Invoke();
	}
}

} // namespace
