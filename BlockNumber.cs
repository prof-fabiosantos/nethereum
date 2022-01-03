using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Nethereum.JsonRpc.UnityClient;

public class BlockNumber : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetBlockNumber());
    }

    private IEnumerator GetBlockNumber()
    {
        string url = "https://ropsten.infura.io/v3/653d8b5b68e0439bbf6c8cf79059a680";
        var blockNumberRequest = new EthBlockNumberUnityRequest(url);
        yield return blockNumberRequest.SendRequest();
        Debug.Log(blockNumberRequest.Result.Value);
    }
}



