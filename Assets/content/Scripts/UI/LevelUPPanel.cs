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
        var idMax = GameManager.Instance.WeaponDatabase.weapons.Length;

        var ids = Utilites.Choose(3, 1, idMax);

        for (int i = 0; i < ids.Length; i++)
        {
            SpawnSlot(new AbilitySlot() { 
                ID = ids[i],
                SlotType = SlotType.Weapon
            });
        }
    }

    private void SpawnSlot(AbilitySlot slot)
    {
        var instance = Instantiate(_slotPrefab, _slotsParent);
        instance.SetData(slot);
    }
}

