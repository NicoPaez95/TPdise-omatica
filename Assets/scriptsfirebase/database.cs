using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Database;

public class database : MonoBehaviour
{


    //BASE DE DATOS//
    private DataPlayer player;

    private DatabaseReference reference;
    
    // Start is called before the first frame update
    void Start()
    {
        reference = FirebaseDatabase.DefaultInstance.RootReference;

        ReadPlayer(PlayerPrefs.GetString("id"));
    }

    private async void ReadPlayer(string id)
    {

        DataSnapshot snapshot = await reference.Child("players").Child(id).GetValueAsync();
        string jsonContent = snapshot.GetRawJsonValue();

        if (jsonContent == null)
        {
            player = new DataPlayer();
            player.id = id;
        }
        else
        {
            player = JsonUtility.FromJson<DataPlayer>(jsonContent);
        }

    }

    public void onclickRestart()
    {
        player.restart++;

        SavePlayer();

    }

    public void onclickStart()
    {
        player.start++;

        SavePlayer();

    }

    private void SavePlayer()
    {

        string json = JsonUtility.ToJson(player);
        reference.Child("players").Child(player.id).SetRawJsonValueAsync(json);

    }

}
