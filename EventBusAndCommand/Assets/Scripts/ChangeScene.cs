using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void changeScene(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }
}
