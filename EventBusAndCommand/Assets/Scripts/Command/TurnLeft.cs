using UnityEngine;

public class TurnLeft : ICommand
{
    private CommandBikeController _controller;

    public TurnLeft(CommandBikeController controller)
    {
        _controller = controller;
    }

    public void Execute()
    {
        _controller.Turn(CommandBikeController.Direction.Left);
    }
}
