using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public ResourceManager resourceManager;
    // Start is called before the first frame update
    void Start()
    {
        resourceManager = GetComponent<ResourceManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
