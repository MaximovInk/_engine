using UnityEngine;

public enum SlotType
{
    Weapon,
    Ability
}

public struct AbilityInfo
{
    public string Name;
    public string Description;
    public Sprite Icon;
}

public class AbilitySlot
{
    public SlotType SlotType;
    public int ID;

    public Sprite GetIcon()
    {
        switch (SlotType)
        {
            case SlotType.Weapon:
                return GameManager.Instance.WeaponDatabase.weapons[ID].Icon;
        }

        return null;
    }

    public void Init()
    {
        var weaponData = GameManager.Instance.WeaponDatabase.weapons[ID];

        var go = new GameObject().AddComponent<WeaponInstance>();

        go.transform.position = Player.Instance.transform.position;
        go.transform.parent = Player.Instance.transform;
        go.weaponData = weaponData;
    }

    public static AbilityInfo GetInfo(AbilitySlot slot)
    {
        switch (slot.SlotType)
        {
            case SlotType.Weapon:
                var weapon =  GameManager.Instance.WeaponDatabase.weapons[slot.ID];

                return new AbilityInfo() {
                    Name = weapon.Name,
                    Description = weapon.Description,
                    Icon = weapon.Icon
                };

        }

        return default;
    }
}

