using UnityEngine;
using System.Collections;

public class MagicAttack : Attack {

	// Use this for initialization
	protected override void Start () {
        base.Start();
        _attackType = AttackType.Type.Magic;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
