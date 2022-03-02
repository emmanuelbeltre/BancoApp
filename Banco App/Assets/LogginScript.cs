using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;

public class LogginScript : MonoBehaviour
{
	
	[Header("Distintas interfaces de las app")]
	public GameObject LoginScreen;
	public GameObject MainScreen;
	
	[Header("Objetos del LoginScreen")]
	public TMP_InputField DNI;
	public TMP_InputField password;
	public TMP_Text incorrecto;
	public Button loggin_btn;
		
		
		
	[Header("Objetos del MainScreen")]
	public TMP_Text hora;
	public Button transacciones_btn;
	public TMP_Text balance;
	public TMP_Text usuario_iniciado;
	public TMP_InputField retirar;
	public  Button retirar_btn;
	
	[Header("Variables MainScreen Internas")]
	public float balance_interno;
	public float retirar_interno;
	public float resultado_interno;
	
	
	[Header("Credenciales")]
	public string user_pass ;
	public string user_dni;
  
  
	
  
  
  
	  void Start()
	{
		//Asigno las pantallas
	    LoginScreen =GameObject.Find("LoginScreen");
	    MainScreen = GameObject.Find("MainScreen");
	
	    
		//Asigno valores del LoginScreen
		DNI	= GameObject.Find("InputField (TMP)DNI"). GetComponent<TMP_InputField>();
		password = GameObject.Find("InputField (TMP)Password").GetComponent<TMP_InputField>();
		incorrecto = GameObject.Find("Text (TMP)incorrecto").GetComponent<TMP_Text>();
		loggin_btn = GameObject.Find("Button Login").GetComponent<Button>();
		user_dni = "1";
		user_pass = "1";
		
		
		//Asigno valores del main Screen
		hora = GameObject.Find("Text (TMP) lastConnection").GetComponent<TMP_Text>();
		transacciones_btn = GameObject.Find("Button Login").GetComponent<Button>();
		balance =  GameObject.Find("Text (TMP)Balance").GetComponent<TMP_Text>();
		usuario_iniciado = GameObject.Find("Text (TMP)UsernameLogged").GetComponent<TMP_Text>();
		
		retirar = GameObject.Find("InputField (TMP) Reterirar").GetComponent<TMP_InputField>();
		retirar.characterValidation =	TMP_InputField.CharacterValidation.Decimal;
		
		retirar_btn = GameObject.Find("Button Retirar").GetComponent<Button>();
		
			//oculto pantallas
		ActivarScreen(LoginScreen);
		
		//Llamo a la función iniciar sesion
		loggin_btn.onClick.AddListener(IniciarSesion);
		
		//Llamo a la función RetirarSaldo
		retirar_btn.onClick.AddListener(RetirarFondos);
		
    }


   
	void ActivarScreen (GameObject PantallaActiva){
		LoginScreen.SetActive(false);
		MainScreen.SetActive(false);
		PantallaActiva.SetActive(true);
	}
	
	void IniciarSesion(){	
		if (DNI.text =="" || password.text =="")
		{
			incorrecto.color= new Color32(10, 255, 76, 136);
			incorrecto.text ="Complete todos los campos antes de ingresar";
			
		}
		
		else	if (DNI.text == user_dni && password.text == user_pass)
		{
			ActivarScreen(MainScreen);
		
		}else
		{
			Debug.Log("Hay bobo");
			incorrecto.color= new Color32(255, 0, 0, 100);
			incorrecto.text = "ERROR de inicio de sesión, aprende a escribir";
		}
	}

	
	void RetirarFondos (){
		//balance.text = balance. - retirar.text;
		
		//balance_interno = float.Parse(balance.text);
		//retirar_interno = float.Parse(retirar.text);
		//float.TryParse(balance.GetParsedText(), out	 balance_interno);
		retirar_interno = float.Parse(retirar.text);
		balance_interno = float.Parse(balance.text);
		 
		resultado_interno = balance_interno - retirar_interno;
		Debug.Log("El balance es : " + balance_interno + "Y la cantidad ingresada es de : " + retirar_interno + ", y el resultado de esta acción es de : " + resultado_interno);

		balance.text=resultado_interno.ToString();
	}

	













}
