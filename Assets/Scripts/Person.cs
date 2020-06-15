using UnityEngine;

[CreateAssetMenu(fileName = "New SwordData", menuName = "SwordData", order = 10)]
public class SwordData : ScriptableObject
{
    [SerializeField]
    private string swordName;
    [SerializeField]
    private string description;
    [SerializeField]
    private Sprite icon;
    [SerializeField]
    private int goldCost;
    [SerializeField]
    private int attackDamage;


}