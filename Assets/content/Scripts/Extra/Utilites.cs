using System.Collections.Generic;
using UnityEngine;

public static class Utilites
{
    public static void ClearAllChildren(Transform transform)
    {
        foreach (Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }

    public static int[] Choose(int k, int min, int max)
    {
        var items = new List<int>();
        for (var i = min; i < max; i++) items.Add(i);

        var choices = new int[k];

        for (var i = 0; i < k && items.Count > 0; i++)
        {
            var index = UnityEngine.Random.Range(0, items.Count);
            choices[i] = items[index];
            items.RemoveAt(index);
        }
        return choices;
    }

    public static float VecToAngle(Vector2 direction)
    {
        return Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
    }


}

