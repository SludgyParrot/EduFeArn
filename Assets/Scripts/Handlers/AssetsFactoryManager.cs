using System;
using System.Collections.Generic;
using UnityEngine;

public class AssetsFactoryManager : Singletons<AssetsFactoryManager>
{
    [SerializeField]
    private List<Sock> sockPrefabs;

    private void Start()
    {
        if (sockPrefabs == null || sockPrefabs.Count == 0)
        {
            throw new InvalidOperationException("Config socks factory failed: Sock prefabs cannot be null/empty.");
        }
    }

    public void CreateAssets(params ItemConfig[] items)
    {
        if(items.Length > sockPrefabs.Count)
        {
            throw new ArgumentOutOfRangeException("Config socks factory failed: The amount of item arguments is greater than the available prefabs.");
        }

        for(int i = 0; i < items.Length; i++)
        {
            Sock sock = sockPrefabs[i];
            sock.Config(items[i]);
        }
    }

    public void HideAllSocks()
    {
        sockPrefabs.ForEach(item => 
        {
            item.HideItem();
        });
    }
}
