using UnityEngine;
using System.Collections;

public class Heal : Action {
    
	// Use this for initialization
	protected override void Start () {
        _thisEntity = GetComponent<Entity>();
    }

    void DoHeal()
    {
        _target = _thisEntity.currentTarget;
        _target.AddCharacteristic(Entity.CharacteristicType.Life, amount);
        _thisEntity.hasDoneAction = true;
    }
}
