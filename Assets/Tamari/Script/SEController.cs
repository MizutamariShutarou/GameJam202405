using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SEController : MonoBehaviour
{
    private static SEController _instance = default;

    public static SEController Instance => _instance;

    [SerializeField] private AudioClip[] _sounds = default;

    private Dictionary<SE, AudioClip> _seDic = new Dictionary<SE, AudioClip>();

    private AudioSource _audioSource = default;
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }

        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        
        _seDic.Add(SE.Attack, _sounds[0]);
        _seDic.Add(SE.Bomb, _sounds[1]);
        _seDic.Add(SE.Conflict, _sounds[2]);
        _seDic.Add(SE.Juice, _sounds[3]);
        _seDic.Add(SE.DontHit, _sounds[4]);
    }

    public void RunSE(SE se)
    {
        _audioSource.PlayOneShot(_seDic[se]);
    }

    public enum SE
    {
        None,
        Attack,
        Bomb,
        Conflict,
        Juice,
        DontHit,
    }
    
}
