using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TMP_InputField displaynameInputField;
    public TMP_InputField emailInputField;
    public TMP_InputField passwordInputField;
    public TextMeshProUGUI statusText;



    public void OnLoginButtonClick()
    {
        string email = emailInputField.text;
        string password = passwordInputField.text;

        ServerManager.Instance.Authenticate(password, email, HandleAuthenticationResponse);
    }

    public void OnCreateAccountButtonClick()
    {
        string email = emailInputField.text;
        string password = passwordInputField.text;
        string displayName = displaynameInputField.text;


        ServerManager.Instance.CreateAccount(displayName, password, email, HandleCreateAccountResponse);
    }

    private void HandleAuthenticationResponse(ServerManager.NetworkResponse response)
    {
        if (response.isSuccess)
        {
            statusText.text = "Authentication successful!";
            SceneManager.LoadScene("Campaign");
        }
        else
        {
            statusText.text = "Authentication failed: " + response.message;
        }
    }

    private void HandleCreateAccountResponse(ServerManager.NetworkResponse response)
    {
        if (response.isSuccess)
        {
            statusText.text = "Account created successfully!";
        }
        else
        {
            statusText.text = "Account creation failed: " + response.message;
        }
    }

}
