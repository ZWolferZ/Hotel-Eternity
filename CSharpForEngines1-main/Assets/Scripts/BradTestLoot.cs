#region Bradloot for reference

public class BradTestLoot : BradLoot
{
    // Made by brad for reference (DO NOT MARK)
    BradTestLoot() : base(10, 1) { }

    public string GetLootName()
    {
        return "BradTestLoot:\n" + GetLootDetails();
    }
}

#endregion