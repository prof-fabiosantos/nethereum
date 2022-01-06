// UpdateLeaderboard.cs
using System.Collections;
using System.Collections.Generic;
using Nethereum.ABI.Model;
using Nethereum.JsonRpc.UnityClient;
using UnityEngine;
using Nethereum.Web3;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Contracts.CQS;
using Nethereum.Util;
using Nethereum.Web3.Accounts;
using Nethereum.Hex.HexConvertors.Extensions;
using Nethereum.Contracts;
using Nethereum.Contracts.Extensions;
using System;
using System.Numerics;
using System.Threading;
using System.Threading.Tasks;
// using contract definition
using Contratos.Contracts.Leaderboard.ContractDefinition;

public class UpdateLeaderboard : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(UpdateScore());
    }

    public IEnumerator UpdateScore()
    {
      
        var contractAddress = "0x9C137494C1733cD8FE469e290f5b3FA41cA3665D";
        var url = "https://ropsten.infura.io/v3/653d8b5b68e0439bbf6c8cf79059a680";
        var privateKey = "3cd656d14571c2f3c39b97dc273060f7653ec6c2fbbb916e717b4e9f1e28f147";
        var account = "0xc144cD60Be02F5d5C6CFfcb56DcE32D99097Afb9";
                
        var transactionTransferRequest = new TransactionSignedUnityRequest(url, privateKey);

        var transactionMessage = new AddScoreFunction
        {
            FromAddress = account,
            User = "Fabio Santos",
            Score = 250000,
        };
        yield return transactionTransferRequest.SignAndSendTransaction(transactionMessage, contractAddress);
        print(transactionTransferRequest.Result);
    }
}


