// Leaderboard.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Nethereum.JsonRpc.UnityClient;
using Contratos.Contracts.Leaderboard.ContractDefinition;
using UnityEngine.UI;
using System;
using System.Text;

public class Leaderboard : MonoBehaviour
{
    Text usuario;
    Text pontos;
   
    void Start()
    {
        StartCoroutine(FetchHighScore());

        usuario = GameObject.Find("Text1").GetComponent<Text>();
        pontos = GameObject.Find("Text2").GetComponent<Text>();
    }

    private IEnumerator FetchHighScore()
    {
        // connect to rinkeby testnet
        string url = "https://ropsten.infura.io/v3/653d8b5b68e0439bbf6c8cf79059a680";
        // leaderboard contract address
        string contractAddress = "0x9C137494C1733cD8FE469e290f5b3FA41cA3665D";
        // fetch highest score
        int leaderboardIndex = 1;
        var queryRequest = new QueryUnityRequest<LeaderboardFunction, LeaderboardOutputDTOBase>(url, contractAddress);
        // call LeaderboardFunctionBase with 1 param (leaderboardIndex) to get the user name score
        yield return queryRequest.Query(new LeaderboardFunction() { ReturnValue1 = leaderboardIndex }, contractAddress);
        usuario.text = queryRequest.Result.User;
        pontos.text = queryRequest.Result.Score.ToString();
    }
}