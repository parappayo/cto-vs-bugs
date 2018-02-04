
using UnityEngine;
using UnityEngine.Events;

namespace CtoVsBugs
{

public class PeriodicTrigger : MonoBehaviour
{
	public UnityEvent Trigger;

	public float Period = 2f;

	private float PeriodTimer;

	private void Update()
	{
		this.PeriodTimer += Time.deltaTime;

		if (this.PeriodTimer >= Period) {
			this.PeriodTimer = 0f;
			this.Trigger.Invoke();
		}
	}
}

} // namespace
