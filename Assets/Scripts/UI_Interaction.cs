using System.Collections.Generic;
using System.Linq;
using Valve.VR;
using UnityEngine;

[System.Serializable]
class PlaceToBe
{
    public string name;
    public Transform spawnPoint;
}

public class UI_Interaction : MonoBehaviour{

    [SerializeField] GameObject player;
    [SerializeField] List<PlaceToBe> locations;
    int places;

    public void TeleportTo(int index) {
        player.transform.position = locations[index].spawnPoint.position;
        places = index;
    }

}
