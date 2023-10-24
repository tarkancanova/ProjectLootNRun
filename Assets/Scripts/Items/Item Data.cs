using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ItemData : ScriptableObject
{
    public string itemName;
    public Sprite icon;
    public GameObject itemModel;
    [TextArea]
    public string Description;
    public Rarity Rarity;
    public int width;
    public int height;
    public List<ItemMods> Mods;
    public ItemType itemType;

}

public enum Rarity
{
    Normal = 0,
    Common = 1,
    Uncommon = 2,
    Magic = 3,
    Rare = 4,
    Unique = 5
}

public enum ItemMods
{
    CriticalStrikeChance = 0,
    CriticalStrikeDamage = 1,
    IncreasedFireDamage = 2,
    IncreasedColdDamage = 3,
    IncreasedLightningDamage = 4,
    IncreasedPhysicalDamage = 5,
    FlatFireDamage = 6,
    FlatColdDamage = 7,
    FlatLightningDamage = 8,
    FlatPhysicalDamage = 9,
    FirePenetration = 10,
    ColdPenetration = 11,
    LightningPenetration = 12,
    PhysicalPenetration = 13
}



public enum ItemType
{
    Orb = 0,
    Weapon = 1,
    Armor = 3
}

