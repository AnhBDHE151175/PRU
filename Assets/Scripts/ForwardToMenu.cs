using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ForwardToMenu : MonoBehaviour
{
    public Button yourButton;

    void Start()
    {
        Debug.Log("Ckcafafaf");
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        SceneManager.LoadScene("Menu");
    }


}
