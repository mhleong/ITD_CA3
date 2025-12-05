using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class Login : MonoBehaviour
{
    public TMP_InputField usernameInput;
    public TMP_InputField passwordInput;
    public TMP_Text feedbackText;
    public void OnLoginButtonPressed()
    {
        string username = usernameInput.text;
        string password = passwordInput.text;

        if (usernameInput.text == "123" && passwordInput.text == "123")
        {
            feedbackText.text = "Login Successful!";
            SceneManager.LoadScene("SampleScene");
            Debug.Log("Login Successful!");
        }
        else
        {   
            feedbackText.text = "Login Failed. Please check your username and password.";
            Debug.Log("Login Failed. Please check your username and password.");
        }
    }
}
