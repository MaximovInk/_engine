using DG.Tweening;
using System.Collections;
using UnityEngine;

public class ExperienceItem : WorldItem
{
    public int Value = 1;

    protected override void OnPickup()
    {
        LevelManager.Instance.LevelData.Experience += Value;

        StartCoroutine(MoveToPlayer());

        //base.OnPickup();
    }

    private IEnumerator MoveToPlayer(float duration = 0.5f)
    {
        float timer = 0;

        var startPos = transform.position;

        while (timer <= duration)
        {
            timer += Time.deltaTime;

            float value = timer / duration;

            var currPos = transform.position;
            var targetPos = Player.Instance.transform.position;

            transform.position = Vector3.Slerp(startPos,targetPos,value);

            yield return null;
        }

        base.OnPickup();
    }
}
