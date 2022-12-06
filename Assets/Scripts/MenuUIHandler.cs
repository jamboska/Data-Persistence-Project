using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIHandler : MonoBehaviour
{
    public TMP_InputField userNameInputField;
    [SerializeField] TextMeshProUGUI bestScoreText;

    // Start is called before the first frame update
    void Start()
    {
        userNameInputField.text = GameDataManager.instance.curUserName;
        bestScoreText.text = "Best Score : " + GameDataManager.instance.highScoreUserName + " : " +
                             GameDataManager.instance.highScorePoints;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UserNameChanged(string name)
    {
        GameDataManager.instance.curUserName = name;
    }

    public void StartButtonClicked()
    {
        SceneManager.LoadScene(1);
    }
}
