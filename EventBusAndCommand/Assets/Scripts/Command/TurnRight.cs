using UnityEngine;

public class TurnRight : ICommand
{
    private CommandBikeController _controller;

    public TurnRight(CommandBikeController controller)
    {
        _controller = controller;
    }

    public void Execute()
    {
        _controller.Turn(CommandBikeController.Direction.Right);
    }
}
