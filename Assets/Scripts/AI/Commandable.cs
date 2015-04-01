using UnityEngine;
using System.Collections;

public abstract class Commandable : MonoBehaviour {
	public abstract void UseTarget(Target t);
}
