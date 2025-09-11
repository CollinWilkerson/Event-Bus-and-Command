using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private Invoker _invoker;
    private bool _isReplaying;
    private bool _isRecording;
    private CommandBikeController _bikeController;
    private ICommand _buttonA, _buttonD, _buttonW;

    private void Start()
    {
        _invoker = gameObject.AddComponent<Invoker>();
        _bikeController = FindAnyObjectByType<CommandBikeController>();

        //attaches buttons to commands for Execute()
        _buttonA = new TurnLeft(_bikeController);
        _buttonD = new TurnRight(_bikeController);
        _buttonW = new ToggleTurbo(_bikeController);
    }

    void Update()
    {
        if (!_isReplaying && _isRecording)
        {
            if (Input.GetKeyUp(KeyCode.A))
                _invoker.ExecuteCommand(_buttonA); //uses invoker to keep track
            if (Input.GetKeyUp(KeyCode.D))
                _invoker.ExecuteCommand(_buttonD);
            if (Input.GetKeyUp(KeyCode.W))
                _invoker.ExecuteCommand(_buttonW);
        }
    }

    void OnGUI()
    {
        if (GUILayout.Button("Start Recording"))
        {
            _bikeController.ResetPosition();
            _isReplaying = false;
            _isRecording = true;
            _invoker.Record();
        }
        if (GUILayout.Button("Stop Recording"))
        {
            _bikeController.ResetPosition();
            _isRecording = false;
        }
        if (!_isRecording)
        {
            if (GUILayout.Button("Start Replay"))
            {
                _bikeController.ResetPosition();
                _isRecording = false;
                _isReplaying = true;
                _invoker.Replay();
            }
        }
    }
}
