using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Auth;
using UnityEngine.Events;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;
public class REGISTER : MonoBehaviour
{
    public InputField IFUSERNAME;

    public InputField IFPASSWORD;

    public Text INVALID;

    private FirebaseUser newUser;


    public void REGISTER1()
    {
        StartCoroutine(DoREGISTER(IFUSERNAME.text, IFPASSWORD.text));
    }

    public IEnumerator DoREGISTER(string email, string password)
    {

        FirebaseAuth auth = FirebaseAuth.DefaultInstance;

        Task<FirebaseUser> registerTask = auth.CreateUserWithEmailAndPasswordAsync(email, password);
        yield return new WaitUntil(() => { return registerTask.IsCompleted; });

        if (registerTask.Exception != null)
        {
            AuthError error = (AuthError)((registerTask.Exception.GetBaseException() as FirebaseException).ErrorCode);
            string errorMessage = $"USUARIO NO VALIDO: {registerTask.Exception.Message} - {error}";
            Debug.Log(errorMessage);
            INVALID.gameObject.SetActive(true);
        }
        else
        {
            Debug.Log("REGISTRADO_EXITOSAMENTE");

            FirebaseUser user = registerTask.Result;

            SceneManager.LoadScene("loginA");

        }

    }



}
