using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class MenuUIHandler : MonoBehaviour
{
    public  TMP_InputField NameInput;
    public TextMeshProUGUI BestScore;
    
    // Start is called before the first frame update
    void Start()
    {
       PlayerData.Instance.LoadScore();
        BestScore.text = $"BestScore:  {PlayerData.Instance.bestplayer} :   {PlayerData.Instance.bestScore} ";
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartNew()
    {
        PlayerData.Instance.playerName = NameInput.text;
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
         EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
