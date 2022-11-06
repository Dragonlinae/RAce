using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class clientonly : NetworkBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    Behaviour CamB;
    void Start()
    {
        if (!IsLocalPlayer)
        {
            CamB.enabled = false;
        }
    }

}
