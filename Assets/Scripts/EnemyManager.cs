using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    //public List<Enemy> enemiesInTrigger = new List<Enemy>();
    public Dictionary<int, Enemy> enemiesInTrigger = new Dictionary<int, Enemy>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void AddEnemy(Enemy enemy)
    {
        enemiesInTrigger.Add(enemy.GetInstanceID(), enemy);
        enemy.Highlight();
    }

    public void RemoveEnemy(Enemy enemy)
    {
        enemiesInTrigger.Remove(enemy.GetInstanceID());
        enemy.DeHighlight();
    }

    public void Print()
    {
        Debug.Log("Enemies");
        foreach (var (key, val) in enemiesInTrigger)
        {
            Debug.Log($"{key} - {val.name}");
        }
    }
}
