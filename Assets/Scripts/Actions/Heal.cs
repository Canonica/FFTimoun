using UnityEngine;
using System.Collections;

public class Heal : Action {

    public GameObject particle;

	// Use this for initialization
	protected override void Start () {
        _thisEntity = GetComponent<Entity>();
        
    }

    public void DoHeal()
    {
        GameObject Fx = Instantiate(particle, this.transform.position, Quaternion.Euler(270f, 0f,0f)) as GameObject;
        Destroy(Fx, 0.5f);
        _target = _thisEntity.currentTarget;
        _target.AddCharacteristic(Entity.CharacteristicType.Life, amount);
        _thisEntity.hasDoneAction = true;
    }
}
