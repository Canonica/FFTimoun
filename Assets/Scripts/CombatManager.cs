using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class CombatManager : MonoBehaviour {

    public static CombatManager instance;

    void Awake()
    {
        if (instance == null)
        {
            //DontDestroyOnLoad(this.gameObject);
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }

    }

    public List<Entity> listOfEntity;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
