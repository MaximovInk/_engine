using UnityEngine;

public class TestManager : MonoBehaviour
{
    public void AddWeapon(int id)
    {
        LevelManager.Instance.AddAbility(
            new AbilitySlot() { 
                ID = id,
                SlotType = SlotType.Weapon
            }
            );
    }

    public void OpenLVLUp()
    {
        LevelUPPanel.Instance.Popup.Show();
    }
}

