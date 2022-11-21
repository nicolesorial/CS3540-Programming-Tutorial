using UnityEngine;

[CreateAssetMenu(menuName = "Inventory Item Data")]
public class ItemData : ScriptableObject
{
    public string id;
    public string displayName;
    public GameObject prefab;

    public override string ToString()
    {
        return displayName;
    }
}
