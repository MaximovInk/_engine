using System;

public struct LevelData
{
    public int Experience
    {
        get => _experience;
        set
        {
            if (_experience < value)
            {
                var addedExp = value - _experience;
                _totalExperience += addedExp;
            }

            _experience = value;
            OnChanged?.Invoke(this);
        }
    }
    private int _experience;

    public int TotalExperience
    {
        get => _totalExperience;
    }

    private int _totalExperience;

    public int Level
    {
        get => _level;
        set
        {
            _level = value;
            OnChanged?.Invoke(this);
        }
    }
    private int _level;

    public int EnemyDeathCount
    {
        get => _enemyDeathCount;
        set
        {
            _enemyDeathCount = value;
            OnChanged?.Invoke(this);
        }
    }

    private int _enemyDeathCount;

    public event Action<LevelData> OnChanged;
}
