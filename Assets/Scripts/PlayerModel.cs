public class PlayerModel
{
    public MoveData MoveData { get; }
    public StateData StateData { get; }

    public PlayerModel()
    {
        MoveData = new MoveData();
        StateData = new StateData();
    }
}