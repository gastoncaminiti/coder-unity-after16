using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LandingController : MonoBehaviour
{
    public enum avatarTypes { Gato, Robot, Pinguino, Fantasma }
    [SerializeField] public Button btnGato;

    // Start is called before the first frame update
    void Start()
    {
        btnGato.onClick.AddListener(delegate { ElegirAvatarType(avatarTypes.Gato); });
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && (ProfileManager.Instance.GetAvatar() != ""))
        {
            SceneManager.LoadScene(1);
        }
    }

    public void ElegirAvatar(string avatarName)
    {
        Debug.Log(avatarName);
        ProfileManager.Instance.SetAvatar(avatarName);
        ProfileManager.Instance.SaveJSON();
    }

    public void ElegirAvatarType(avatarTypes newType)
    {
        Debug.Log(newType);
    }
}
