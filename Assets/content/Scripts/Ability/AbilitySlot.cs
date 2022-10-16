using UnityEngine;

public enum SlotType
{
    Weapon,
    Ability
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
}

