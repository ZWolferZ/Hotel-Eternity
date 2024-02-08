using UnityEngine;

public class BradLoot : MonoBehaviour
{
    protected int Value;
    protected int Weight;
    protected GameObject Item;
    [SerializeField]
    protected string Name;

    protected BradLoot(int value, int weight)
    {
        Value = value;
        Weight = weight;
        Item = this.gameObject;
    }

    protected string GetLootDetails()
    {
        return "Value: " + Value + "\n" +
            "Weight: " + Weight;
    }
}