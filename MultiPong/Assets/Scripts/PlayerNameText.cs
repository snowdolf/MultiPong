using UnityEngine;
using UnityEngine.UI;

public class PlayerNameText : MonoBehaviour
{
    private Text nameText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        nameText = GetComponent<Text>();

        if (AuthManager.User != null)
        {
            nameText.text = $"Hi, {AuthManager.User.Email}";
        }
        else
        {
            nameText.text = "ERROR: User not found!";
        }
    }
}
