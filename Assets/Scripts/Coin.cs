using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(80 * Time.deltaTime, 0, 0); // This allows the coin to rotate by 40 on the x axis each second and the y and the z axis rotation is kept at 0
    }

    private void OnTriggerEnter(Collider other) // This function checks if something triggers the coin collider
    {
        if(other.tag == "Player") // This checks if only the player has triggered the coin
        {
            PlayerManager.coinCounter += 1; // This increments the coin counter which is in the PlayerManager script by 1 each time a coin is triggered
            Destroy(gameObject); // This then destroys the coin after the collider is triggered
        }
    }
}
