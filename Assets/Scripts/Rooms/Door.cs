using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Door : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform previousRoom;
    [SerializeField] private Transform nextRoom;

    [SerializeField] private CameraController cam;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (other.transform.position.x < transform.position.x)
            {
                cam.MoveToNewRoom(nextRoom);
                nextRoom.GetComponent<Rooms>().ActivateRoom(true);
                previousRoom.GetComponent<Rooms>().ActivateRoom(false);
            }
            else
            {
                cam.MoveToNewRoom(previousRoom);
                previousRoom.GetComponent<Rooms>().ActivateRoom(true);
                nextRoom.GetComponent<Rooms>().ActivateRoom(false);

            }
        }
    }
}
