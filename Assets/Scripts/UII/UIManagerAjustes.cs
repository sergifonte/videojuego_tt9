using UnityEngine;
using UnityEngine.SceneManagement;
public class UIManagerAjustes : MonoBehaviour
{
    public void ChangeToLevel()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
    
}
