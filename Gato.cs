using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Gato : MonoBehaviour
{
    public Button btn;
	public Text txtJuego;
	public AudioSource reproductor;
	public AudioClip   sndWIn, sndBtnJuego, sndGameOver;
	

    private int[,] matrizGato = new int[3, 3];
    private int turno = 0; //Nadie ha iniciado
	private int ganador = 0, movimientos = 0;
    


    // Start is called before the first frame update
	void Start(){
		reproductor = gameObject.GetComponent<AudioSource>();
	    IniciaGato();
	    txtJuego.text = "Juego Nuevo";

    }

    public void AsignaTurno(Button btn){
        if (ObtenValoresMatriz(btn.name) == 0 && ganador == 0){

            if (turno == 0) { //Inicia el Juego
	            turno = 1; // Inicia X
            } else if (turno == 1){
	            turno = 2; //Continua las O 

            } else {
                turno = 1; // Continuan las X
            }
	        reproductor.PlayOneShot(sndBtnJuego);
	        txtJuego.text = "Juego en Curso";
            DibujaSimbolo(btn , turno);
            EscribirElValorMatriz(btn.name, turno); 
            movimientos++;
	        VerificaGanador();
        }

    }

    private void DibujaSimbolo(Button btn, int t){
	    if (t == 1 ){
		    btn.GetComponentInChildren<Text>().text = "X";

	    }else{
		    btn.GetComponentInChildren<Text>().text = "O";
        }

    }

    private int ObtenValoresMatriz(string btn){
        int a = -1;
        switch (btn){
            case "G0":
                a = matrizGato[0,0];
                break;
            case "G1":
                a = matrizGato[0,1];
                break;
            case "G2":
                a = matrizGato[0,2];
                break;
            case "G3":
                a = matrizGato[1,0];
                break;
            case "G4":
                a = matrizGato[1,1];
                break;
            case "G5":
                a = matrizGato[1,2];
                break;
            case "G6":
                a = matrizGato[2,0];
                break;
            case "G7":
                a = matrizGato[2,1];
                break;
            case "G8":
                a = matrizGato[2,2];
                break;
        }
        return a;
        Debug.Log("Btn Presionado " + a.ToString());
    }

	private void EscribirElValorMatriz(string btn,int t){
        switch (btn){
            case "G0":
                matrizGato[0,0] = t;
                break;
            case "G1":
                matrizGato[0,1] = t;
                break;
            case "G2":
                matrizGato[0,2] = t;
                break;
            case "G3":
                matrizGato[1,0] = t;
                break;
            case "G4":
                matrizGato[1,1] = t;
                break;
            case "G5":
                matrizGato[1,2] = t;
                break;
            case "G6":
                matrizGato[2,0] = t;
                break;
            case "G7":
                matrizGato[2,1] = t;
                break;
            case "G8":
                matrizGato[2,2] = t;
                break;

        }

    }

    private void VerificaGanador(){
        if (matrizGato[0,0] == 1 && matrizGato[0,1] == 1 && matrizGato[0,2] == 1) {
            ganador = 1; //Gana X Primer renglon
        }
        if (matrizGato[1,0] == 1 && matrizGato[1,1] == 1 && matrizGato[1,2] == 1) {
            ganador = 1; //Gana X Segundo renglon
        }
        if (matrizGato[2,0] == 1 && matrizGato[2,1] == 1 && matrizGato[2,2] == 1) {
            ganador = 1; //Gana X Tercer renglon
        }


        if (matrizGato[0,0] == 2 && matrizGato[0,1] == 2 && matrizGato[0,2] == 2) {
            ganador = 2; //Gana O Primer Renglon
        }
        if (matrizGato[1,0] == 2 && matrizGato[1,1] == 2 && matrizGato[1,2] == 2) {
            ganador = 2; //Gana O Segundo Renglon
        }
        if (matrizGato[2,0] == 2 && matrizGato[2,1] == 2 && matrizGato[2,2] == 2) {
            ganador = 2; //Gana O Tercer renglon
        }




        if (matrizGato[0,0] == 1 && matrizGato[1,0] == 1 && matrizGato[2,0] == 1){
            ganador = 1; //Gana X Primera columna 
        }
        if (matrizGato[0,1] == 1 && matrizGato[1,1] == 1 && matrizGato[2,1] == 1){
            ganador = 1; //Gana X Segunda columna
        }
        if (matrizGato[0,2] == 1 && matrizGato[1,2] == 1 && matrizGato[2,2] == 1){
            ganador = 1; //Gana X Tercera Columna
        }


        if (matrizGato[0,0] == 2 && matrizGato[1,0] == 2 && matrizGato[2,0] == 2){
            ganador = 2; //Gana O Primera columna 
        }
        if (matrizGato[0,1] == 2 && matrizGato[1,1] == 2 && matrizGato[2,1] == 2){
            ganador = 2; //Gana O Segunda columna
        }
        if (matrizGato[0,2] == 2 && matrizGato[1,2] == 2 && matrizGato[2,2] == 2){
            ganador = 2; //Gana O Tercera Columna
        }


        if (matrizGato[0,0] == 1 && matrizGato [1,1] == 1 && matrizGato [2,2] == 1){
            ganador = 1; // Gana X en la diagonal principal
        }
        if (matrizGato[0,0] == 2 && matrizGato [1,1] == 2 && matrizGato [2,2] == 2){
            ganador = 2; // Gana O en la diagonal principal
        }


        if (matrizGato [0,2] == 1 && matrizGato [1,1] == 1 && matrizGato [2,0] == 1){
            ganador = 1; // Gana X en la diagonal Inversa
        }
        if (matrizGato[0,2] == 2 && matrizGato [1,1] == 2 && matrizGato [2,0] == 2){
            ganador = 2; // Gana O en la diagonal Inversa 
        }

        if (ganador == 0 && movimientos == 9){
	        txtJuego.text = "Empate";
	        reproductor.PlayOneShot(sndGameOver);
        }

	    if (ganador == 1){
		    txtJuego.text = "Ganador = X";
		    reproductor.PlayOneShot(sndWIn);
        }

        if (ganador == 2){
	        txtJuego.text = "Ganador = O";
	        reproductor.PlayOneShot(sndWIn);

        }
	    
        
        



        

        
    }

    private void IniciaGato(){
        //Inicia la Matriz en Ceros

        for (int i = 0; i < 3; i++){
            for (int j = 0; j < 3; j++) {
                matrizGato[i,j] = 0;

            }
        }

        //Borra los textos de los botones
        GameObject.Find("G0").GetComponentInChildren<Text>().text = "";
        GameObject.Find("G1").GetComponentInChildren<Text>().text = "";
        GameObject.Find("G2").GetComponentInChildren<Text>().text = "";
        GameObject.Find("G3").GetComponentInChildren<Text>().text = "";
        GameObject.Find("G4").GetComponentInChildren<Text>().text = "";
        GameObject.Find("G5").GetComponentInChildren<Text>().text = "";
        GameObject.Find("G6").GetComponentInChildren<Text>().text = "";
        GameObject.Find("G7").GetComponentInChildren<Text>().text = "";
        GameObject.Find("G8").GetComponentInChildren<Text>().text = "";
    }

	public void ReiniciaJuego(){
	    SceneManager.LoadScene("Main");
       
    }
    

}
