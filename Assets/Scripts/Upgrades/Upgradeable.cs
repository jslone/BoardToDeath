using UnityEngine;
using System.Collections;

public class Upgradeable : MonoBehaviour {
	public static int MAX_UPGRADE_LEVEL = 4;

	public float[] Costs = new float[MAX_UPGRADE_LEVEL];
	public float Cost { get { return UpgradeLevel + 1 < Costs.Length ? Costs[UpgradeLevel+1] : float.PositiveInfinity; } }
	public int UpgradeLevel;
	public Animator animator;


	public bool CanUpgrade() {
		return UpgradeLevel < Costs.Length && Cost <= Souls.souls && (!gameObject.activeSelf || animator.GetInteger("level") == UpgradeLevel);
	}

	public void BuyUpgrade() {
		if(CanUpgrade()) {
			Souls.souls -= Mathf.RoundToInt(Cost);
			Upgrade();
		}
	}

	public void Upgrade() {
		if(CanUpgrade()) {
			gameObject.SetActive(true);
			UpgradeLevel++;
		}
	}

	void Update() {
		animator.SetInteger("level", UpgradeLevel);
	}
}
