using UnityEngine;
using System.Collections;

public class Action : MonoBehaviour {

    
   
    public float amount;
    protected Entity _target;
    protected Entity _thisEntity;
    // Use this for initialization
    protected virtual void Start () {
        _thisEntity = GetComponent<Entity>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
