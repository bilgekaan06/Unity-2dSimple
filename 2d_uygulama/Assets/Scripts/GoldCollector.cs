using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldCollector : MonoBehaviour {

	void Start () {
		
	}
	
	void Update () {
		
	}
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            MainCharacter.goldCounter++;
            gameObject.SetActive(false);// topladığımız altınları görünmez hale getiriyoruz...
            Invoke("Uyan", 1f);
        }
    }
    void Uyan()
    {
        gameObject.SetActive(true);//burada da tekrar aktifleştiriyoruz...
    }
}
