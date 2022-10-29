
using UnityEngine;

public abstract class WeaponDriver
{
    public WeaponInstance instance;

    public virtual void Init(WeaponInstance instance)
    {
        this.instance = instance;
    }

    public virtual void Update() { }
    public virtual void Attack()
    {
        var clip = instance.weaponData.attackSound;
        if(clip != null)
        {
            LevelManager.Instance.AudioSource.PlayOneShot(clip);
        }
    }
}