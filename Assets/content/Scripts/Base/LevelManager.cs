using UnityEngine;
public class LevelManager : MonoBehaviourSingleton<LevelManager>
{
    public LevelData LevelData = new LevelData();

    public LevelCounterLogic LevelCounter = new LevelCounterLogic();

    [SerializeField]
    private ExperienceItem ExperienceItem;

    public void SpawnExperienceAt(Vector3 position)
    {
        var exp = Instantiate(ExperienceItem);
        exp.transform.position = position;
    }

    private void Awake()
    {
        LevelData.OnChanged += (data) =>
        {
            if(LevelCounter.UpdateLevel(data.Experience, data.Level))
            {
                LevelData.Level++;
                LevelData.Experience = 0;
            }
        };
    }
}

