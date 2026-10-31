using UnityEngine;
using UnityEngine.Video;

// A planet button on the console.
// The public methods are connected to the XR Simple Interactable events in the Inspector.
public class PlanetButton : MonoBehaviour
{
    [Header("Content")]
    public VideoClip video;
    public VideoScreen screen;

    [Header("Button parts")]
    public Transform planet;
    public GameObject selectedEffects; // ring + light, shown while selected

    [Header("Sound")]
    public AudioSource audioSource;
    public AudioClip clickSound;

    [Header("Feedback settings")]
    public float hoverScale = 1.15f;
    public float selectedScale = 1.1f;
    public float pressDepth = 0.015f;
    public float hoverRotationSpeed = 60f;
    public float selectedRotationSpeed = 20f;

    bool isHovered;
    bool isPressed;
    bool isSelected;

    Vector3 originalScale;
    Vector3 originalPosition;

    void Awake()
    {
        originalScale = planet.localScale;
        originalPosition = planet.localPosition;
        selectedEffects.SetActive(false);
    }

    void Update()
    {
        UpdateScale();
        UpdatePosition();
        UpdateRotation();
    }

    // Hovered: the planet grows. Selected: it stays slightly bigger.
    void UpdateScale()
    {
        Vector3 targetScale = originalScale;
        if (isHovered)
        {
            targetScale = originalScale * hoverScale;
        }
        else if (isSelected)
        {
            targetScale = originalScale * selectedScale;
        }

        // Lerp moves smoothly towards the target instead of jumping to it.
        planet.localScale = Vector3.Lerp(planet.localScale, targetScale, 12f * Time.deltaTime);
    }

    // Pressed: the planet sinks into the console.
    void UpdatePosition()
    {
        Vector3 targetPosition = originalPosition;
        if (isPressed)
        {
            targetPosition = originalPosition + Vector3.down * pressDepth;
        }

        planet.localPosition = Vector3.Lerp(planet.localPosition, targetPosition, 20f * Time.deltaTime);
    }

    // Hovered: spins fast. Selected: spins slowly. Otherwise: stays still.
    void UpdateRotation()
    {
        float speed = 0f;
        if (isHovered)
        {
            speed = hoverRotationSpeed;
        }
        else if (isSelected)
        {
            speed = selectedRotationSpeed;
        }

        planet.Rotate(0f, speed * Time.deltaTime, 0f, Space.Self);
    }

    public void OnHoverEnter()
    {
        isHovered = true;

        // Same click sound, higher pitch and quieter, as a light "tick".
        audioSource.pitch = 1.6f;
        audioSource.PlayOneShot(clickSound, 0.3f);
    }

    public void OnHoverExit()
    {
        isHovered = false;
    }

    public void OnPress()
    {
        isPressed = true;

        audioSource.pitch = 1f;
        audioSource.PlayOneShot(clickSound);

        screen.Show(this);
    }

    public void OnRelease()
    {
        isPressed = false;
    }

    // Called by the screen when this planet becomes (or stops being) the selected one.
    public void SetSelected(bool selected)
    {
        isSelected = selected;
        selectedEffects.SetActive(selected);
    }
}