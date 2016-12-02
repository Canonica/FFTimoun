using UnityEngine;
using System.Collections;

public class Attack : Action {
    protected AttackType.Type _attackType;
    private Animator anim;
	// Use this for initialization
	protected override void Start () {
        base.Start();
        anim = GetComponent<Animator>();

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void DoAttack()
    {
        anim.SetTrigger("StartAttack");
        _target = _thisEntity.currentTarget;
        amount = amount + Random.Range(-5, 5);
        _target.ReceiveDamage(_attackType, amount);
        _thisEntity.hasDoneAction = true;
    }
}
