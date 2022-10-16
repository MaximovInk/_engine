using UnityEngine;
using UnityEngine.UI;

public class EntityHealthDrawer : MonoBehaviour
{
    public GameObject healthBar;
    public Slider HealthSlider;

    private Entity _entity;

    private void Awake()
    {
        _entity = GetComponentInParent<Entity>();

        _entity.onDamage += (int value) => {
            healthBar.gameObject.SetActive(true);
            HealthSlider.value = _entity.GetHealthRelative();
        };
    }
}

