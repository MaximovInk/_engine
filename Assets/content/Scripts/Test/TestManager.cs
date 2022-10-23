using TMPro;
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

    public void MakeEnemy()
    {
        LevelManager.Instance.MakeEnemy(
            Player.Instance.transform.position 
            + new Vector3(Random.Range(-10,10), Random.Range(-10, 10), 0));
    }

    

    public void SpeedUPTime()
    {
        Time.timeScale += 0.2f;
    }

    public void SpeedDownTime()
    {
        Time.timeScale -= 0.2f;
    }

    public TextMeshProUGUI timeScaleTest;

    private void Update()
    {
        if(timeScaleTest != null)
        {
            timeScaleTest.text = $"Speed: {Time.timeScale}x";
        }
    }
}

