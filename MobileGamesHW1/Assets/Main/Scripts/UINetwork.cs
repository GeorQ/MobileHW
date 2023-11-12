using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class UINetwork : MonoBehaviour
{
    public Button hostButton;
    public Button serverButton;
    public Button clientButton;

    private void Awake()
    {
        hostButton.onClick.AddListener(OnHostClick);
        serverButton.onClick.AddListener(OnServerClick);
        clientButton.onClick.AddListener(OnClientClick);
    }

    private void OnHostClick()
    {
        NetworkManager.Singleton.StartHost();
        gameObject.SetActive(false);
    }
    
    private void OnServerClick()
    {
        NetworkManager.Singleton.StartServer();
        gameObject.SetActive(false);
    }

    private void OnClientClick()
    {
        NetworkManager.Singleton.StartClient();
        gameObject.SetActive(false);
    }
}