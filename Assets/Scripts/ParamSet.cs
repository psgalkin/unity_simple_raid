using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Character", menuName = "ParamSet", order = 1)]
public class ParamSet : ScriptableObject
{
    [SerializeField]
    public float Health;

    [SerializeField]
    public float Damage;
}