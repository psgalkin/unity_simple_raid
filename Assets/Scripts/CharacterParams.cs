using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterParams : MonoBehaviour
{
    public ParamSet startParams;

    public float Health
    { set; get; }

    public float Damage
    { set;  get; }

    private void Start()
    {
        Health = startParams.Health;
        Damage = startParams.Damage;
    }

    public void ApplyDamage(float p_damage)
    {
        if ((Health -= p_damage) < 0) {
            Health = 0;
        }
    }
}
