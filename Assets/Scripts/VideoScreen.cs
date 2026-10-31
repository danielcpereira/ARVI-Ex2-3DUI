using UnityEngine;
using UnityEngine.Video;

// The observatory screen.
// Plays the video of the chosen planet and dims the console light while a video is playing.
[RequireComponent(typeof(VideoPlayer))]
public class VideoScreen : MonoBehaviour
{
    [Header("Lighting")]
    public Light consoleLight;
    public float normalIntensity = 3f;
    public float cinemaIntensity = 0.5f;

    VideoPlayer videoPlayer;
    PlanetButton currentButton;

    void Awake()
    {
        videoPlayer = GetComponent<VideoPlayer>();
    }

    void Update()
    {
        float targetIntensity = normalIntensity;
        if (videoPlayer.isPlaying)
        {
            targetIntensity = cinemaIntensity;
        }

        consoleLight.intensity = Mathf.Lerp(consoleLight.intensity, targetIntensity, 3f * Time.deltaTime);
    }

    public void Show(PlanetButton button)
    {
        // Pressing the planet that is already selected pauses or resumes its video.
        if (button == currentButton)
        {
            TogglePause();
            return;
        }

        // Only one planet can be selected at a time.
        if (currentButton != null)
        {
            currentButton.SetSelected(false);
        }

        currentButton = button;
        currentButton.SetSelected(true);

        videoPlayer.clip = button.video;
        videoPlayer.Play();
    }

    void TogglePause()
    {
        if (videoPlayer.isPlaying)
        {
            videoPlayer.Pause();
        }
        else
        {
            videoPlayer.Play();
        }
    }
}