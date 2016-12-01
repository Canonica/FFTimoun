using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class CombatManager : MonoBehaviour {
    public static CombatManager instance;
    public List<Entity> playerEntities = new List<Entity>();
    public List<Entity> enemyEntities = new List<Entity>();


    void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(this.gameObject);
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }
    }

    public void RemoveFromList(Entity entity)
    {
        if(entity.currentCamp == Entity.Camp.Player)
        {
            playerEntities.Remove(entity);
        }
        else if(entity.currentCamp == Entity.Camp.Enemy)
        {
            enemyEntities.Remove(entity);
        }
    }


}
