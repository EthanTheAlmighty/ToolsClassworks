using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyHeroClass : MonoBehaviour {

    public string heroName;

    public int armorAmt;
    public int healthAmt;
    public int manaPool;

    [System.Serializable]
    public struct Spell
    {
        public string spellName;
        public int manaCost;
        public bool isDamaging;
        public int totalAmount;
    }

    public Spell mySpell;

    public WeaponClass myWeapon;

    void Start()
    {

    }

    void Update()
    {

    }
}
