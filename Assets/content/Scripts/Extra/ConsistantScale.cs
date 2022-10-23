using UnityEngine;

public class ConsistantScale : MonoBehaviour
{
    private void Update()
    {
        var newScale = transform.localScale;
        if (transform.parent.localScale.x == -1)
            newScale.x = -1;
        else
            newScale.x = 1;

        transform.localScale = newScale;
    }
}

