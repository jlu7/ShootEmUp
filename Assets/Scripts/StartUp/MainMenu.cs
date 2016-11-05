using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenu : MonoBehaviour
{
	void Start ()
    {
        Button StartButton = this.transform.Find("Button").GetComponent<Button>();
        StartButton.onClick.AddListener(() => StartGame());
	}

    private void StartGame()
    {
        GameController.GetInstance().CreateView("Prefabs/Level1");
    }
}
