using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Button playBtn, quitBtn, shopBtn;

    void Awake() => Init();

    void Init()
    {
        if (playBtn == null) playBtn = GameObject.Find(StringHandler.Btn_Play).GetComponent<Button>();
        if (quitBtn == null) quitBtn = GameObject.Find(StringHandler.Btn_Quit).GetComponent<Button>();
        if (shopBtn == null) shopBtn = GameObject.Find(StringHandler.Btn_Info).GetComponent<Button>();

        // Implement Button Onclick
        playBtn.onClick.AddListener(PlayGame);
        quitBtn.onClick.AddListener(QuitApp);
        shopBtn.onClick.AddListener(Shop);
    }
    private void Info()
    {
        Application.OpenURL("https://itch.io/profile/imatendra");
    }


    private void QuitApp()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void PlayGame()
    {
        // To Load GameScene
        SceneManager.LoadScene("GameMode");
        FindAnyObjectByType<CanvasManager>().SwitchCanvas(CanvasType.GameUI);
    }
    
    private void Shop()
    {
        FindAnyObjectByType<CanvasManager>().SwitchCanvas(CanvasType.SelectionUI);
        FindAnyObjectByType<CharacterLoader>().PreviewCharacter();
    }

}
