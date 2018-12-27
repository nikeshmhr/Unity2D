using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class UserInterface : MonoBehaviour {

    private Sprite pauseTransparent;
    private Sprite playTransparent;
    private Sprite pauseOpaque;
    private Sprite playOpaque;
    private AudioSource audioSource;    // AudioSource related to UI

    private bool isPaused = false;
    // References
    public Button playPauseButton;
    public AudioClip playPauseClip;

    public void Start() {
        // Load all sprites in atlas
        Sprite[] uiIconSprites = Resources.LoadAll<Sprite>("user-interface");
        // Get specific sprite
        pauseTransparent = uiIconSprites.Single(s => s.name == "pause-transparent");
        playTransparent = uiIconSprites.Single(s => s.name == "play-transparent");
        pauseOpaque = uiIconSprites.Single(s => s.name == "pause-opaque");
        playOpaque = uiIconSprites.Single(s => s.name == "play-opaque");
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayPauseGame() {
        audioSource.clip = playPauseClip;
        audioSource.Play();

        SpriteState ss = new SpriteState();
        if (isPaused) {
            Time.timeScale = 1;

            // Change the sprite icon to pause
            playPauseButton.GetComponent<Image>().sprite = pauseTransparent;

            ss.pressedSprite = pauseOpaque;
            playPauseButton.GetComponent<Button>().spriteState = ss;
        } else {
            Time.timeScale = 0;

            // Change the sprite icon to play
            playPauseButton.GetComponent<Image>().sprite = playTransparent;

            ss.pressedSprite = playOpaque;
            playPauseButton.GetComponent<Button>().spriteState = ss;
        }
        isPaused = !isPaused;
    }
}
