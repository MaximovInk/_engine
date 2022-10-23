using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelUPPanel : MonoBehaviourSingleton<LevelUPPanel>
{
    [SerializeField]
    private LevelUPSlot _slotPrefab;
    [SerializeField]
    private Transform _slotsParent;
    [SerializeField]
    private Popup _popup;

    public Popup Popup => _popup;

    private void Awake()
    {
        _popup.onBeginShow += () =>
        {
            Pause.Instance.IsPause = true;
            GenerateData();
        };

        _popup.onEndHide += () => {
            Pause.Instance.IsPause = false;
        };
    }

    private void GenerateData()
    {
        Utilites.ClearAllChildren(_slotsParent);

        List<AbilitySlot> availableSlots = new List<AbilitySlot>();

        var weapons = GameManager.Instance.WeaponDatabase.weapons.ToArray();
        var abilites = GameManager.Instance.AbilityDatabase.abilites.ToArray();

        for (int i = 1; i < weapons.Length; i++)
        {
            availableSlots.Add(new AbilitySlot() {
                ID = i,
                SlotType = SlotType.Weapon
            });
        }

        for(int i = 1; i < abilites.Length; i++)
        {
            availableSlots.Add(new AbilitySlot()
            {
                ID = i,
                SlotType = SlotType.Ability
            });
        }

        var slots = LevelManager.Instance.GetAbilites();

        for (int i = 0; i < slots.Count; i++)
        {
            var index = availableSlots
                .FirstOrDefault(n => 
                n.ID == slots[i].ID &&
                n.SlotType == slots[i].SlotType);

            availableSlots.Remove(index);
        }

        print($"{weapons.Length} {abilites.Length} {availableSlots.Count}");

        for (int i = 0; i < 3; i++)
        {
            if (availableSlots.Count <= 0) break;

            var id = Random.Range(0, availableSlots.Count);
            SpawnSlot(availableSlots[id]);
            availableSlots.RemoveAt(id);
        }
    }

    private void SpawnSlot(AbilitySlot slot)
    {
        var instance = Instantiate(_slotPrefab, _slotsParent);
        instance.SetData(slot);
    }
}

