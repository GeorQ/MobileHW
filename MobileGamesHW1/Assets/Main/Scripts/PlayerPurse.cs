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
        if (!IsOwner)
        {
            return;
        }
        playerMoney += ammount;
        moneyText.text = playerMoney.ToString();
        if (playerMoney > 20)
        {
            SuperTestServerRpc();
        }
    }

    [ServerRpc(RequireOwnership = false)]
    public void SuperTestServerRpc()
    {
        SuperTestClientRpc();
    }

    [ClientRpc]
    private void SuperTestClientRpc()
    {
        if (playerMoney >= 20)
        {
            transform.GetComponent<BaranovskyStudio.PlayerMovement>().WinScreen();
        }
        else
        {
            transform.GetComponent<BaranovskyStudio.PlayerMovement>().GameOverScreen();
        }
    }
}