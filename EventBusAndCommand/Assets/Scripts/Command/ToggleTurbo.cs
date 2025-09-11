using UnityEngine;

public class ToggleTurbo: ICommand
{
    private CommandBikeController _controller;
    public ToggleTurbo(CommandBikeController controller)
    {
        _controller = controller;
    }

    public void Execute()
    {
        _controller.ToggleTurbo();
    }
}
