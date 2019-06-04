using System.Collections.Generic;
using System.Linq;
using Valve.VR;
using UnityEngine;

[System.Serializable]
class PlaceToBe
{
    public string name;
    public GameObject place;
    public Transform spawnPoint;
    public bool isOutDoor;
}

public class UI_Interaction : MonoBehaviour{

    [SerializeField] GameObject player;
    [SerializeField] List<PlaceToBe> locations;
    int places;

    public void TeleportTo(int index) {
        locations[places].place.SetActive(false);
        locations[index].place.SetActive(true);
        player.transform.position = locations[index].spawnPoint.position;
        places = index;
    }

}
