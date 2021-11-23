using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ProfileManager : MonoBehaviour
{
    public static ProfileManager Instance;

    [SerializeField] private string avatar;

    void Awake()
    {
        // start of new code
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        
    }

    // Start is called before the first frame update
    void Start()
    {
        Instance.LoadJSON();
        Debug.Log("EL AVATAR GUARDADO ES "+avatar);
    }
     
    public void SetAvatar(string newAvatar)
    {
        Instance.avatar = newAvatar;
    }

    public string GetAvatar()
    {
        return Instance.avatar;
    }

    [System.Serializable]
    class ProfileData
    {
        public string Avatar;
    }

    public void SaveJSON()
    {
        //CREAR OBJETO DE CLASE PROFILEDATA
        ProfileData data = new ProfileData();
        //ASIGNAR NUEVOS VALORES A LA DATA A ALMACENAR
        data.Avatar = avatar;
        //TRASFORMAR EN UN STRING EN FORMATO JSON
        string json = JsonUtility.ToJson(data);
        //ESCRIBIR UN ARCHIVO DONDE EL CONTENIDO ES EL JSON
        File.WriteAllText(Application.persistentDataPath + "/profile.json", json);
    }

    public void LoadJSON()
    {
        //DEFINIMOS LA RUTA DEL JSON 
        string path = Application.persistentDataPath + "/profile.json";
        //SI EXISTE UN ARCHIVO EN ESTA RUTA
        if (File.Exists(path))
        {
            //OBTENEMOS EL TEXTO DEL ARCHIVO (EL TEXTO ESTA EN FORMATO JSON)
            string json = File.ReadAllText(path);
            //TRANFORMAMOS EL JSON EN UN OBJETO PROFILE DATA
            ProfileData data = JsonUtility.FromJson<ProfileData>(json);
            //ASIGNAMOS LA INFORMACION GUARDAD A LAS VARIABLES
            avatar = data.Avatar;
        }
    }
}
