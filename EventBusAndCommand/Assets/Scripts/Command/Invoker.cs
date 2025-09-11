using UnityEngine;
using System.Linq;
using System.Collections.Generic;
public class Invoker : MonoBehaviour
{
    private bool _isRecording;
    private bool _isReplaying;
    private float _replayTime;
    private float _recordingTime;
    private SortedList<float, ICommand> _recordedCommands = 
        new SortedList<float, ICommand>();

    public void ExecuteCommand(ICommand command)
    {
        //command does its in game action
        command.Execute();

        //stores command and play time in the list
        if (_isRecording)
        {
            _recordedCommands.Add(_recordingTime, command);
        }

        Debug.Log("Recorded Time: " + _recordingTime);
        Debug.Log("Recorded Command: " + command);
    }

    public void Record()
    {
        _recordingTime = 0.0f;
        _isRecording = true;
    }

    public void Replay()
    {
        _replayTime = 0.0f;
        _isReplaying = true;
        if (_recordedCommands.Count <= 0)
            Debug.LogError("No commands to replay!");
        //reverses command list so they play in the proper order
        //this could be more efficent because when we add commands we dont have to find the end of the list
        _recordedCommands.Reverse();
    }

    void FixedUpdate()
    {
        //keeps recording time up to date
        if (_isRecording)
            _recordingTime += Time.fixedDeltaTime;
        if (_isReplaying)
        {
            //compensates for the lack of persision from fixed
            _replayTime += Time.deltaTime;
            if (_recordedCommands.Any())
            {
                //if we are close to the recorded time, play command
                if (Mathf.Approximately(
                _replayTime, _recordedCommands.Keys[0]))
                {
                    Debug.Log("Replay Time: " + _replayTime);
                    Debug.Log("Replay Command: " +
                    _recordedCommands.Values[0]);
                    _recordedCommands.Values[0].Execute();
                    _recordedCommands.RemoveAt(0);
                }
            }
            else
            {
                _isReplaying = false;
            }
        }
    }
}
