public class ExperienceItem : WorldItem
{
    public int Value = 1;

    protected override void OnPickup()
    {
        base.OnPickup();

        LevelManager.Instance.LevelData.Experience += Value;
    }
}
