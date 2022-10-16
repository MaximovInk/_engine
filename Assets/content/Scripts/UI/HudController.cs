using System.Collections;
using UnityEngine;

public class HudController : MonoBehaviourSingletonAuto<HudController>
{
    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
