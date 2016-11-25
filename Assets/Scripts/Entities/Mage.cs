using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Mage : Entity {

    // Use this for initialization
    protected override void Start () {
        base.Start();
        archetype = Archetype.CurrentArchetype.Mage;
        attackPreference = AttackType.Type.Magic;
	}
	
}
