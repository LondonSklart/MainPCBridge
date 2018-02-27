﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{

    public List<BaseStat> stats = new List<BaseStat>();






	// Use this for initialization
	void Start ()
    {
        stats.Add(new BaseStat(4, "Power", "Your power level"));
        stats.Add(new BaseStat(5, "Health", "Your health level"));


    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.C))
        {
            Debug.Log(stats[0].GetCalculatedValue());
            Debug.Log(stats[1].GetCalculatedValue());
        }


    }
    public void AddStatBonus(List<BaseStat> statBonuses)
    {
        foreach (BaseStat s in statBonuses)
        {
            stats.Find(x => x.StatName == s.StatName).AddBonus(new StatBonus(s.BaseValue));
        }
    }

    public void RemoveStatBonus(List<BaseStat> statBonuses)
    {
        foreach (BaseStat s in statBonuses)
        {
            stats.Find(x => x.StatName == s.StatName).RemoveBonus(new StatBonus(s.BaseValue));
        }
    }



}
