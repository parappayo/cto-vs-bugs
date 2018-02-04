
using UnityEngine;

namespace CtoVsBugs
{

public class RadialSpawner : MonoBehaviour, ISpawner
{
	public GameObject Spawnable;
	public Transform Parent;

	public float Radius = 1f;

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(transform.position, this.Radius);
	}

	public void Spawn()
	{
		float theta = Random.Range(0f, Mathf.PI * 2f);
		float phi = Random.Range(0f, Mathf.PI * 2f);
		Vector3 offset = SphericalPoint(this.Radius, theta, phi);

		SpawnTools.Spawn(this.Spawnable, this.transform.position + offset, this.Parent);
	}

	public static Vector3 SphericalPoint(float radius, float theta, float phi)
	{
		return new Vector3(
			radius * Mathf.Sin(theta) * Mathf.Cos(phi),
			radius * Mathf.Sin(theta) * Mathf.Sin(phi),
			radius * Mathf.Cos(theta));
	}
}

} // namespace
