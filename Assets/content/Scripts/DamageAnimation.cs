using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class DamageAnimation : MonoBehaviour
{
    private Entity _entity;

    public Color DamageColor;

    public float Duration = 0.2f;
    public float Rate = 0.1f;

    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _entity = GetComponent<Entity>();

        _entity.onDamage += (int val) => 
        {
            if (isAnimating) return;

            StopAllCoroutines();
            StartCoroutine(DamageAnimationRoutine());
        };
    }

    private bool isAnimating = false;

    private IEnumerator DamageAnimationRoutine()
    {
        isAnimating = true;

        float timer = 0;

        float rateTimer = 0;

        var mat = _spriteRenderer.material;

        mat.SetInt("_SpriteMode",2);

        mat.SetColor("_ColorOverride", DamageColor) ;

        bool light = true;

        while (true)
        {
            timer += Time.deltaTime;

            rateTimer += Time.deltaTime;

            if(rateTimer > Rate)
            {
                rateTimer = 0;

                mat.SetInt("_SpriteMode", light ? 1 : 2);

                light = false;
            }

            if (timer > Duration) break;

            yield return null;
        }

        mat.SetInt("_SpriteMode", 1);

        isAnimating = false;
    }
}
