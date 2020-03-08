using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnDestroy : MonoBehaviour
{
    public string clipName;

    private void OnDestroy()
    {
        GameManager.Instance.GetComponent<SoundController>().Play(clipName);
    }
}