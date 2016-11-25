using UnityEngine;
using System.Collections;

public class Warrior : Entity {

	// Use this for initialization
	protected override void Start () {
        base.Start();
        archetype = Archetype.CurrentArchetype.Warrior;
        attackPreference = AttackType.Type.Physical;
	}
	
}
