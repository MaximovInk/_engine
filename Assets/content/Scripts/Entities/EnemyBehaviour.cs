public abstract class EnemyBehaviour
{
    public abstract void Init(Enemy controller);

    public abstract void Update(Enemy controller);
}

public class EnemyPlayerTargetBehaviour : EnemyBehaviour
{

    public override void Init(Enemy controller)
    {

    }

    public override void Update(Enemy controller)
    {
        if (Player.Instance == null)
        {
            controller.behaviour = null;
            return;
        }

        var moveDir = (Player.Instance.transform.position - controller.transform.position).normalized;

        controller.Entity.MoveInput = moveDir;

    }
}
