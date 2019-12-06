using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Messaging : MonoBehaviour
{
    public Text message;
    public GameObject messenger;

    public void Stop()
    {
        message.text = "Move Back!!!";
        messenger.SetActive(true);
        StartCoroutine(closeMessage());
    }

    IEnumerator closeMessage()
    {
        yield return new WaitForSeconds(2f);
        messenger.SetActive(false);
    }
}
