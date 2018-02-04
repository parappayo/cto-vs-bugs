
using System.Collections.Generic;
using UnityEngine;

namespace CtoVsBugs
{

public class AlignedBoxSpawner : MonoBehaviour, ISpawner
{
	public GameObject Spawnable;
	public Transform Parent;

	public Vector3 Size = new Vector3(1f, 0f, 1f);
	public Vector3 Spacing = new Vector3(1f, 1f, 1f);

	public bool OffsetOddRows = true;

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireCube(transform.position + (Size * 0.5f), Size);
	}

	private void SpawnRow(Vector3 offset)
	{
		for (float x = 0f; x <= Size.x; x += Spacing.x) {
			var position = transform.position + offset;
			position.x += x;

			SpawnTools.Spawn(this.Spawnable, position, this.Parent);
		}
	}

	private void SpawnFloor(Vector3 offset)
	{
		bool oddRow = false;

		for (float z = 0f; z <= Size.z; z += Spacing.z) {
			SpawnRow(new Vector3(
				offset.x + (oddRow ? Spacing.x * 0.5f : 0f),
				offset.y,
				offset.z + z));

			oddRow = OffsetOddRows ? !oddRow : oddRow;
		}
	}

	public void Spawn()
	{
		if (Spacing.x <= 0f || Spacing.y <= 0f || Spacing.z <= 0f) { return; }

		bool oddRow = false;

		for (float y = 0f; y <= Size.y; y += Spacing.y) {
			SpawnFloor(new Vector3(
				0f,
                y,
                oddRow ? Spacing.z * 0.5f : 0f));

			oddRow = OffsetOddRows ? !oddRow : oddRow;
		}
	}
}

} // namespace
