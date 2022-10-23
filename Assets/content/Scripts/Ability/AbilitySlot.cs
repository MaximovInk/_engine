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
            case SlotType.Ability:
                return GameManager.Instance.AbilityDatabase.abilites[ID].Icon;
        }

        return null;
    }

    public void Init()
    {
        if (SlotType == SlotType.Weapon)
        {

            var weaponData = GameManager.Instance.WeaponDatabase.weapons[ID];

            var go = new GameObject().AddComponent<WeaponInstance>();

            go.transform.position = Player.Instance.transform.position;
            go.transform.parent = Player.Instance.transform;
            go.weaponData = weaponData;
        }
        else
        {
            Debug.Log("INIT ABILITY *TODO*");

            var ability = GameManager.Instance.AbilityDatabase.abilites[ID];

            switch (ability.Type)
            {
                case AbilityType.PlayerSpeed:
                    Player.Instance.Entity.Speed *= ability.Value;

                    break;
                case AbilityType.AddDuration:


                    break;
                case AbilityType.ProjectileSpeed:
                    break;
                case AbilityType.Size:
                    break;
                case AbilityType.Damage:
                    break;
                case AbilityType.AddProjectile:
                    break;
                default:
                    break;
            }
        }
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
           case SlotType.Ability:
                var ability = GameManager.Instance.AbilityDatabase.abilites[slot.ID];

                return new AbilityInfo()
                {
                    Name = ability.Name,
                    Description = ability.Description,
                    Icon = ability.Icon
                };
        }

        Debug.Log("RETURN DEFAULT??");
        return default;
    }
}

