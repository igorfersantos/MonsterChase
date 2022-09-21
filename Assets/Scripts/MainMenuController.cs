using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenuController : MonoBehaviour
{
    private static int ToPlayerIndex(string clickedButton) => clickedButton switch
    {
        "Button_Select_Player_1" => 0,
        "Button_Select_Player_2" => 1,


        _ => throw new System.ArgumentOutOfRangeException(
            nameof(clickedButton),
            $"Not expected clickedButton value: {clickedButton}"
            ),
    };

    public void PlayGame()
    {
        string clickedObject = EventSystem.current.currentSelectedGameObject.name;

        try
        {
            GameManager.instance.CharIndex = ToPlayerIndex(clickedObject);
            SceneManager.LoadScene("Gameplay");
        }
        catch (System.Exception e)
        {
            Debug.Log($"Invalid character selected. Exception:\n{e.Message}");
        }
    }
}
