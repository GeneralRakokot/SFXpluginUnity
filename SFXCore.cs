using System.Collections;
using UnityEngine;

public static class SFXCore
{
    private static GameObject SFXRoot = null;
    private static ArrayList SFXNodes = new ArrayList();

    //Main method for plaing SFXeffects (name - sound name in folder "Resources", randomPitch - variability).
    //You can create "Resources" folder anywhere.
    public static void Play(string name, float randomPitch = 0.15f)
    {
        if (name == "")
        {
            //Debug.Log("Empty name");
            return;
        }

        AudioSource FreeNode = FindFreeNode();
        FreeNode.clip = Resources.Load<AudioClip>(name);

        randomPitch = Mathf.Clamp(randomPitch, 0f, 1f);
        float currentPitch = UnityEngine.Random.Range(1f - randomPitch, 1f + randomPitch);
        FreeNode.pitch = currentPitch;

        FreeNode.Play();
    }

    public static void Play(string[] names, float randomPitch = 0.15f)
    {
        if (names.Length == 0)
        {
            //Debug.Log("Empty names array");
            return;
        }

        AudioSource FreeNode = FindFreeNode();
        string name = names[Random.Range(0, names.Length - 1)];
        FreeNode.clip = Resources.Load<AudioClip>(name);

        randomPitch = Mathf.Clamp(randomPitch, 0f, 1f);
        float currentPitch = Random.Range(1f - randomPitch, 1f + randomPitch);
        FreeNode.pitch = currentPitch;

        FreeNode.Play();
    }

    private static AudioSource FindFreeNode()
    {
        foreach (AudioSource audioNode in SFXNodes)
        {
            if (!audioNode.isPlaying)
            {
                return audioNode;
            }
        }
        return CreateSFXNode();
    }

    static AudioSource CreateSFXNode()
    {
        if (SFXRoot == null)
        {
        SFXRoot = new GameObject("SFXRoot");
        Object.DontDestroyOnLoad(SFXRoot);
        }

        GameObject obj = new GameObject("Effect" + SFXNodes.Count);
        obj.transform.SetParent(SFXRoot.transform);
        AudioSource audioSource = obj.AddComponent<AudioSource>();

        SFXNodes.Add(audioSource);

        return audioSource;
    }
}
