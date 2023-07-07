using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuUIHandler : MonoBehaviour
{

    public Canvas canvas;
    public TMP_InputField usernameField;
    public TextMeshProUGUI title; 

    private void Start()
    {
        //load data if there is on //making references to canvas UI
        if(GameManager.Instance != null)
        {
            
                title.text = "Highest Score: " + GameManager.Instance.highestUsername + " -> " + GameManager.Instance.highestScore.ToString();
            
        } 
    }

    public void StartGame()
    {
        string username = usernameField.text;
        GameManager.Instance.StoreCurrentUser(username);
        //store the user name
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
    Application.Quit();
#endif
    }





    //for data persistence, i only need to save and update the highest score at the end of the game which is called

    //preserve user name from the input field 
}
