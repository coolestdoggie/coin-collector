public class PlayerModel
{
    public MoveData MoveData { get; }

    public PlayerModel()
    {
        MoveData = new MoveData();
    }
}

public class MoveData
{
    public float Speed { get; } = 3;
}