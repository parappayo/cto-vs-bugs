
using UnityEngine;

namespace CtoVsBugs
{

public class SpawnTools
{
	static public GameObject Spawn(GameObject spawnable, Vector3 position, Transform parent = null)
	{
		var spawn = Object.Instantiate(spawnable) as GameObject;

		if (parent != null) {
			spawn.transform.parent = parent;
		}

		spawn.transform.position = position;
		return spawn;
	}
}

} // namespace
