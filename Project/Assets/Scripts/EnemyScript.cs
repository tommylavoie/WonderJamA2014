using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {

    int vie;
    int force;
    int déplacement;
    int type; 
    /* 0 = rapide mais faible (dep4, 
     * 1 = tank
     * 2 = Lent mais tres fort
    */


	// Use this for initialization
	void Start () {
        
        
	}
	
	// Update is called once per frame
	void Update () {
	

	}

    // Function
    void Deplacement() { 
        Random.Range(0, 4)
    }


}
