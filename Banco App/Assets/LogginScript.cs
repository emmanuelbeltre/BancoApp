using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;

public class LogginScript : MonoBehaviour
{
	
	public TextMesh miTexto;
	
	[Header("Distintas interfaces de las app")]
	public GameObject LoginScreen ;
	public GameObject MainScreen;
	public GameObject TranssactionScreen;
	
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
	public TMP_Text msg_error;
	public Button historial;
	public Button salir;
	
	[Header("Variables MainScreen Internas")]
	public float balance_interno;
	public float retirar_interno;
	public float resultado_interno;
	
	
	[Header("Credenciales")]
	public string user_pass ;
	public string user_dni;
  
  
	[Header("Variables extras")]
	float Min = 12;
	float Max= 12;
  
  
  
	  void Start()
	{
		miTexto= gameObject.AddComponent<TextMesh>();
		miTexto.text="Esta funcionando";
		miTexto.font = Resources.Load("Fonts/ARIAL", typeof(Font)) as Font ;
		
		miTexto.fontSize = 60;
		//Asigno las pantallas
	    LoginScreen =GameObject.Find("LoginScreen");
		MainScreen = GameObject.Find("MainScreen");
		TranssactionScreen= GameObject.Find("TransaccionesScreen");
	
	    
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
		//retirar.onValueChanged.AddListener(msg_error.text="");
		
		
		retirar_btn = GameObject.Find("Button Retirar").GetComponent<Button>();
		msg_error = GameObject.Find("Text (TMP)MsgError").GetComponent<TMP_Text>();
		historial = GameObject.Find("ButtonHistorial").GetComponent<Button>();
		salir =  GameObject.Find("ButtonSalir").GetComponent<Button>();
		
		
			//oculto pantallas
		ActivarScreen(LoginScreen);
		
		//Llamo a la función iniciar sesion
		loggin_btn.onClick.AddListener(IniciarSesion);
		
		//Llamo a la función RetirarSaldo
		retirar_btn.onClick.AddListener(RetirarFondos);
		
		//Cerrar sesión
		salir.onClick.AddListener(CerrarSesion);
		
		
		//Navegar a HistorialScreen
		historial.onClick.AddListener(NavegarHistorial);
		
    }


   
	void ActivarScreen (GameObject PantallaActiva){
		LoginScreen.SetActive(false);
		MainScreen.SetActive(false);
		TranssactionScreen.SetActive(false);
	
		PantallaActiva.SetActive(true);
	}
	
	void IniciarSesion(){	
		if (DNI.text =="" || password.text =="")
		{
			incorrecto.color= new Color32(10, 255, 76, 136);
			incorrecto.text ="Complete todos los campos antes de ingresar.";
			
			
		}
		
		else	if (DNI.text == user_dni && password.text == user_pass)
		{
			ActivarScreen(MainScreen);
		
		}else
		{
			Debug.Log("Hay bobo");
			incorrecto.color= new Color32(255, 0, 0, 100);
			incorrecto.text = "ERROR de inicio de sesión, aprende a escribir.";
		}
	}

	
	void RetirarFondos (){
		//balance.text = balance. - retirar.text;
		
		//balance_interno = float.Parse(balance.text);
		//retirar_interno = float.Parse(retirar.text);
		//float.TryParse(balance.GetParsedText(), out	 balance_interno);
		
		if(retirar.text ==""){
			msg_error.text ="Debe ingresar una cantidad para hacer un retiro válido.";
			msg_error.color = new Color32 (10,255,76,136);
			return;
			
		}
		
		retirar_interno = float.Parse(retirar.text);
		balance_interno = float.Parse(balance.text);
		 
		//balance_interno = Mathf.Clamp(balance_interno,Min, Max);
	
			if (retirar_interno > balance_interno)
		{
				msg_error.text = "La cantida " + retirar.text +"$ excede su balance actual de " + balance.text + "$ pesos";
			msg_error.color = new Color32(255,0,0,100);
			retirar.text ="";
			return;
		}
			else if (retirar_interno > 0){
			resultado_interno = balance_interno - retirar_interno;
			msg_error.text="";
				balance.text=resultado_interno.ToString();
				return;
			} else
			{
				msg_error.text = "No puede retirar la cantidad de " + retirar.text + " pesos";
				msg_error.color = new Color32(255,0,0,100);
				retirar.text ="";
				return;
			}
			
		
		Debug.Log("El balance es : " + balance.text + "Y la cantidad ingresada es de : " + retirar.text + ", y el resultado de esta acción es de : " + resultado_interno);

	
	}

	void CerrarSesion(){
			ActivarScreen(LoginScreen);
	}
	
	void NavegarHistorial(){
		ActivarScreen(TranssactionScreen);
	}
	
	
	
	// Update is called every frame, if the MonoBehaviour is enabled.
	protected void Update()
	{ 
	
	}

}