public class BradTestLoot : BradLoot
{
    BradTestLoot() : base(10, 1) { }

    public string GetLootName()
    {
        return "BradTestLoot:\n" + GetLootDetails();
    }
}