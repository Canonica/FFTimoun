using UnityEngine;
using System.Collections;

public class PhysicalAttack : Attack {

	// Use this for initialization
	protected override void Start () {
        base.Start();
        _attackType = AttackType.Type.Physical;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
