using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;

public class NetworkManagerUI : MonoBehaviour
{
    [SerializeField]Button serverBtn;
    [SerializeField]Button clientBtn;
    [SerializeField]Button hostBtn;


    private void Awake() {
        serverBtn.onClick.AddListener (() =>
        {   
            NetworkManager.Singleton.StartServer();
        });
        clientBtn.onClick.AddListener (() =>
        {   
            NetworkManager.Singleton.StartClient();
        });
        hostBtn.onClick.AddListener (() =>
        {   
            NetworkManager.Singleton.StartHost();
        });
    }
}
