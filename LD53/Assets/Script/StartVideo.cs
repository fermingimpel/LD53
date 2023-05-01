using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;


public class StartVideo : MonoBehaviour
{
    [SerializeField] string nameToNextScene;
    VideoPlayer videoPlayer;

    private void Awake()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.loopPointReached += OnVideoEnd;

    }
    void OnSkip()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        videoPlayer.Stop();
        SceneManager.LoadScene(nameToNextScene);
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        SceneManager.LoadScene(nameToNextScene);
    }
}
