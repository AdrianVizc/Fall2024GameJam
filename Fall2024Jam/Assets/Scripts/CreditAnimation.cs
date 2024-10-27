using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimationSceneChanger : MonoBehaviour
{
    
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene("MainMenuScene");
    }
}
