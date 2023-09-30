using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Presiona : MonoBehaviour {
	
	public void MainAInicio(){
		SceneManager.LoadScene("Inicio");
	}
	
	public void MainAInfo(){
		SceneManager.LoadScene("Informacion");
	}
	
	

	void Update(){
    	

		if (Input.GetKey(KeyCode.Space)){
			SceneManager.LoadScene("Main");
			
			
		}
		
	    
	    
	}
   
}

    

