using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    
    public static MainMenu mainMenu;

    public Button playButton;

    // Flag to indicate if restart or play button sprite
    public static bool isRestart = false;

    private Sprite playOpaque;
    private Sprite restartOpaque;
    private AudioSource audioSource;


    private void Awake() {
        if(mainMenu == null) {
            mainMenu = GameObject.Find("_GM").GetComponent<MainMenu>();
        }
    }

    // Use this for initialization
    void Start () {
        // Load all sprites in atlas
        Sprite[] uiIconSprites = Resources.LoadAll<Sprite>("user-interface");
        // Get specific sprite
        restartOpaque = uiIconSprites.Single(s => s.name == "restart-opaque");
        playOpaque = uiIconSprites.Single(s => s.name == "play-opaque");

        // Update icon
        if (isRestart) {
            mainMenu.playButton.GetComponent<Image>().sprite = mainMenu.restartOpaque;
        } else {
            mainMenu.playButton.GetComponent<Image>().sprite = mainMenu.playOpaque;
        }

        audioSource = GetComponent<AudioSource>();
    }

    public void PlayRestartGame() {
        StartCoroutine(WaitAndStartScene());
    }

    private IEnumerator WaitAndStartScene() {
        audioSource.Play();
        yield return new WaitForSeconds(0.9f);
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    public void QuitGame() {
        audioSource.Play();
        Application.Quit();
    }
}
