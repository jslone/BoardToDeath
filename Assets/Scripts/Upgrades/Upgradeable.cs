using UnityEngine;
using System.Collections;

public class Upgradeable : MonoBehaviour {
	public float Cost;
	public int UpgradeLevel;
	public Animator animator;
	public static int MAX_UPGRADE_LEVEL = 4;

	public bool CanUpgrade() {
		return UpgradeLevel < MAX_UPGRADE_LEVEL && Cost <= Souls.souls && (!animator || animator.GetInteger("level") == UpgradeLevel);
	}
	
	public void Upgrade() {
		if(CanUpgrade()) {
			gameObject.SetActive(true);
			UpgradeLevel++;
		}
	}
}
