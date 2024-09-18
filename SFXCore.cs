using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering;

public class SFXCore
{
    static GameObject SFXNode = null;
    static ArrayList SFXEffects = new ArrayList();
    public static void Enter()
    {
        if (SFXNode == null)
        {
            GameObject EmptyObject = new GameObject("SFXNode");
            EmptyObject.transform.parent = Global.Anchor.transform;

            SFXNode = EmptyObject;
        }
    }

    public static void Play(string name)
    {
        AudioSource FreeNode = FindFreeSFXEffect();
        FreeNode.clip = Resources.Load<AudioClip>(name);

        float randomPitch = UnityEngine.Random.Range(0.95f, 1.05f);
        FreeNode.pitch = randomPitch;

        FreeNode.Play();
    }

    private static AudioSource CreateSFXEffectNode()
    {
        if (SFXNode != null)
        {
            GameObject EmptyObject = new GameObject(SFXEffects.Count.ToString());
            EmptyObject.transform.parent = SFXNode.transform;
            AudioSource newAudioSource = EmptyObject.AddComponent<AudioSource>();
            SFXEffects.Add(newAudioSource);
            return newAudioSource;
        }
        Debug.Log("SFXNode not found!!!!!");
        return null;
    }
    private static AudioSource FindFreeSFXEffect()
    {
        //if (SFXEffects.Count == 0) { return CreateSFXEffectNode(); }
        foreach (AudioSource effect in SFXEffects) 
        { 
            if (!effect.isPlaying)
            {
                return effect;
            }
        }
        return CreateSFXEffectNode();
    }
}
