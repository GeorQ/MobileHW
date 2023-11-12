using UnityEngine;
using TMPro;
using Unity.Netcode;

public class PlayerPurse : NetworkBehaviour
{
    public TMP_Text moneyText;

    private int playerMoney;

    public override void OnNetworkSpawn()
    {
        playerMoney = 0;
        moneyText.text = playerMoney.ToString();
    }

    public void AddMoney(int ammount)
    {
        playerMoney += ammount;
        moneyText.text = playerMoney.ToString();
        if (playerMoney > 20)
        {
            ulong wonId = OwnerClientId;
            NetworkManager.Singleton.ConnectedClients[wonId].PlayerObject.transform.GetComponentInChildren<BaranovskyStudio.PlayerMovement>().WinScreen();
            for (int i = 0; i < NetworkManager.Singleton.ConnectedClientsIds.Count; i++)
            {
                if (NetworkManager.Singleton.ConnectedClientsIds[i] != wonId)
                {
                    NetworkManager.Singleton.ConnectedClients[(ulong)i].PlayerObject.transform.GetComponentInChildren<BaranovskyStudio.PlayerMovement>().GameOverScreen();
                }
            }
        }
    }
}