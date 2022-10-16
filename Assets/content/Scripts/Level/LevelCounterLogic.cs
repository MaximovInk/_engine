
public class LevelCounterLogic
{
    private const int baseLvlNeedExp = 7;
    private const float lvlAddExp = 0.5f;

    public float GetExperienceRelative(LevelData data)
    {
        var max = CalcExpNeed(data.Level);

        return (float)data.Experience / max;
    }

    public int CalcExpNeed(int level)
    {
        return (int)(baseLvlNeedExp + baseLvlNeedExp * level * lvlAddExp);
    }

    public bool UpdateLevel(int experience, int level)
    {
        return experience >= CalcExpNeed(level);
    }
}
