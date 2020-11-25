using System;
using System.Collections;
using System.Threading.Tasks;
using Firebase;
using Firebase.Auth;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
    public InputField ifusername;
    public InputField ifpassword;

    public Text TXTERROR;
    public void Login1()
    {
        StartCoroutine(DoLogin(ifusername.text, ifpassword.text));

    }

    public IEnumerator DoLogin(string email, string password)
    {

        FirebaseAuth auth = FirebaseAuth.DefaultInstance;

        Task<FirebaseUser> registerTask = auth.SignInWithEmailAndPasswordAsync(email, password);
        yield return new WaitUntil(() => { return registerTask.IsCompleted; });

        if (registerTask.Exception != null)
        {
            AuthError error = (AuthError)((registerTask.Exception.GetBaseException() as FirebaseException).ErrorCode);
            string errorMessage = $"Cannot register user: {registerTask.Exception.Message} - {error}";
            Debug.Log(errorMessage);
            TXTERROR.gameObject.SetActive(true);
        }
        else
        {
            Debug.Log("logeadoexitosamente");

            FirebaseUser user = registerTask.Result;
            PlayerPrefs.SetString("id", user.UserId);
            PlayerPrefs.Save();
            SceneManager.LoadScene("SampleScene");

        }

    }

}
