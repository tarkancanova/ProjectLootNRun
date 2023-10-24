using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;


public class IncreasedCriticalChanceModifier : IItemModifier
{
    public float magnitude;

    public IncreasedCriticalChanceModifier(float magnitude)
    {
        this.magnitude = magnitude;
    }

    public void ApplyModifier(ItemData item)
    {
        item.Mods.Add(ItemMods.CriticalStrikeChance);
    }
}

public class IncreasedCriticalDamageModifier : IItemModifier
{
    public float magnitude;

    public IncreasedCriticalDamageModifier(float magnitude)
    {
        this.magnitude = magnitude;
    }

    public void ApplyModifier(ItemData item)
    {
        item.Mods.Add(ItemMods.CriticalStrikeDamage);
    }
}

public class IncreasedFireDamage : IItemModifier
{
    public float magnitude;

    public IncreasedFireDamage(float magnitude)
    {
        this.magnitude = magnitude;
    }

    public void ApplyModifier(ItemData item)
    {
        item.Mods.Add(ItemMods.IncreasedFireDamage);
    }
}

public class IncreasedColdDamage : IItemModifier
{
    public float magnitude;

    public IncreasedColdDamage(float magnitude)
    {
        this.magnitude = magnitude;
    }

    public void ApplyModifier(ItemData item)
    {
        item.Mods.Add(ItemMods.IncreasedColdDamage);
    }
}

public class IncreasedLightningDamage : IItemModifier
{
    public float magnitude;

    public IncreasedLightningDamage(float magnitude)
    {
        this.magnitude = magnitude;
    }

    public void ApplyModifier(ItemData item)
    {
        item.Mods.Add(ItemMods.IncreasedLightningDamage);
    }
}

public class IncreasedPhysicalDamage : IItemModifier
{
    public float magnitude;

    public IncreasedPhysicalDamage(float magnitude)
    {
        this.magnitude = magnitude;
    }

    public void ApplyModifier(ItemData item)
    {
        item.Mods.Add(ItemMods.IncreasedPhysicalDamage);
    }
}

public class FlatFireDamage : IItemModifier
{
    public float magnitude;

    public FlatFireDamage(float magnitude)
    {
        this.magnitude = magnitude;
    }

    public void ApplyModifier(ItemData item)
    {
        item.Mods.Add(ItemMods.FlatFireDamage);
    }
}

public class FlatColdDamage : IItemModifier
{
    public float magnitude;

    public FlatColdDamage(float magnitude)
    {
        this.magnitude = magnitude;
    }

    public void ApplyModifier(ItemData item)
    {
        item.Mods.Add(ItemMods.FlatColdDamage);
    }
}

public class FlatLightningDamage : IItemModifier
{
    public float magnitude;

    public FlatLightningDamage(float magnitude)
    {
        this.magnitude = magnitude;
    }

    public void ApplyModifier(ItemData item)
    {
        item.Mods.Add(ItemMods.FlatLightningDamage);
    }
}

public class FlatPhysicalDamage : IItemModifier
{
    public float magnitude;

    public FlatPhysicalDamage(float magnitude)
    {
        this.magnitude = magnitude;
    }

    public void ApplyModifier(ItemData item)
    {
        item.Mods.Add(ItemMods.FlatPhysicalDamage);
    }
}
