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
	public GameObject AlertScreen;
	
	[Header("Objetos del LoginScreen")]
	public TMP_InputField DNI;
	public TMP_InputField password;
	public TMP_Text incorrecto;
	public Button loggin_btn;
	public Toggle recordar;

		
		
		
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
	
	
	[Header("Objetos del Transactions Screen")]
	public Button volver;
	public Button salirHistorial;
	public TMP_Text transaccionesHistorial;
	
	
	[Header ("Objetos del Alert Screen")]
	public Button cerrarAera;
	public Button cerrarAlerta;
	public string alertaEnPantalla;
	public TMP_Text  mensajeAlerta;
	
	
	[Header("Credenciales")]
	public string user_pass ;
	public string user_dni;
  
  
	[Header("Variables extras")]
	public	string [] arreglo  ;
	public string resultado_arreglo;
	public int currentIndex;
	public string contenedor;
  
	  void Start()
	{
		
		miTexto= gameObject.AddComponent<TextMesh>();
		miTexto.text="Está funcionando";
		miTexto.font = Resources.Load("Fonts/ARIAL", typeof(Font)) as Font ;
		
		miTexto.fontSize = 60;
		//Asigno las pantallas
	    LoginScreen =GameObject.Find("LoginScreen");
		MainScreen = GameObject.Find("MainScreen");
		TranssactionScreen= GameObject.Find("TransaccionesScreen");
	
	    
		//Asigno objetos / valores del LoginScreen
		DNI	= GameObject.Find("InputField (TMP)DNI"). GetComponent<TMP_InputField>();
		password = GameObject.Find("InputField (TMP)Password").GetComponent<TMP_InputField>();
		//password.contentType = InputField.ContentType.Standard;
		//password.inputType =InputField.ContentType.Password;
		password.contentType=	TMP_InputField.ContentType.Password;
		
		password.characterValidation= TMP_InputField.CharacterValidation.Digit;
		incorrecto = GameObject.Find("Text (TMP)incorrecto").GetComponent<TMP_Text>();
		loggin_btn = GameObject.Find("Button Login").GetComponent<Button>();
		recordar = GameObject.Find("Toggle Remember").GetComponent<Toggle>();
		user_dni = "Emma";
		user_pass = "123";
		
		
		//Asigno onjetos / valores del main Screen
		transacciones_btn = GameObject.Find("Button Login").GetComponent<Button>();
		balance =  GameObject.Find("Text (TMP)Balance").GetComponent<TMP_Text>();
		usuario_iniciado = GameObject.Find("Text (TMP)UsernameLogged").GetComponent<TMP_Text>();
		retirar = GameObject.Find("InputField (TMP) Reterirar").GetComponent<TMP_InputField>();
		retirar.characterValidation =	TMP_InputField.CharacterValidation.Digit;	
		
		retirar_btn = GameObject.Find("Button Retirar").GetComponent<Button>();
		msg_error = GameObject.Find("Text (TMP)MsgError").GetComponent<TMP_Text>();
		historial = GameObject.Find("ButtonHistorial").GetComponent<Button>();
		salir =  GameObject.Find("ButtonSalir").GetComponent<Button>();
		hora = GameObject.Find("Text (TMP) lastConnection").GetComponent<TMP_Text>();
		hora.color = new Color32(10,255,76,136);
		
		
		//Asigno los objetos/valores del Transacton Screen
		volver = GameObject.Find("ButtonVolver").GetComponent<Button>();
		salirHistorial = GameObject.Find("ButtonSalirHistorial").GetComponent<Button>();
		transaccionesHistorial = GameObject.Find("Text (TMP)TransaccionesHistorial").GetComponent<TMP_Text>();
		
		
		//Asigno los objetos/valores del Alert Screen
		AlertScreen= GameObject.Find("MensajeAlertaScreen");
		cerrarAera = GameObject.Find("Button de Area").GetComponent<Button>();
		cerrarAlerta = GameObject.Find("ButtonCerraVentana").GetComponent<Button>();
		mensajeAlerta = GameObject.Find("Text (TMP) MensajeAlerta").GetComponent<TMP_Text>();
		
		
		
		
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
		
		//boton Volver a MainScreen
		volver.onClick.AddListener(NavegarMainScreen);
		
		//boton cerrar sesión desde transactions screen
		salirHistorial.onClick.AddListener(CerrarSesion);
		
		//Cerrar Alerta
		cerrarAera.onClick.AddListener(NavegarMainScreen);
		cerrarAlerta.onClick.AddListener(NavegarMainScreen);
    }


   
	void ActivarScreen (GameObject PantallaActiva){
		LoginScreen.SetActive(false);
		MainScreen.SetActive(false);
		TranssactionScreen.SetActive(false);
		AlertScreen.SetActive(false);
	
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
			hora.text = System.DateTime.Now.ToString();
			incorrecto.text ="";
		
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
				
				if (retirar_interno < 100)
				{
					msg_error.text = "No puede hacer retiros menores a 100$ pesos";
					return;
				}
				if (retirar_interno % 100 !=0)
				{
					msg_error.text ="Cantidad invalidad, pruebe con cantidades como : \n \n 100$   300$    500$   1000$   20000$";
					return;
					
				}
				AlertScreen.SetActive(true	);
				mensajeAlerta.text = "Sutransacción de " +  retirar_interno.ToString() + "$ Pesos se ha procesado con éxito en la fecha :   " + System.DateTime.Now.ToString() + "\n \n" + "¡GRACIAS POR UTILIZAR NUESTROS SERVICIOS!";
				resultado_interno = balance_interno - retirar_interno;
				
				
				msg_error.text="";
				balance.text=resultado_interno.ToString();
				retirar.text="";
			
			
			
			
				
			 
				contenedor =  contenedor +"Ha hecho una transacción de "+ retirar_interno.ToString() + " $ pesos el día " + System.DateTime.Now.ToString()+ "\n" + "\n"+ "\n" ;
				
				transaccionesHistorial.text = contenedor;
				//retirar_interno  = retirar_interno + retirar_interno;
				//transaccionesHistorial.text = retirar_interno.ToString();
				//for (int i = 0; i < arreglo.Length; i++) {
				//	Debug.Log("Funciona");
				//	arreglo[i]= transaccionesHistorial.text;
					
				//	transaccionesHistorial.text = arreglo[i];
					
				//	Debug.Log(arreglo[1]=transaccionesHistorial.text );
				//}
				return;
			} else
			{
				msg_error.text = "No puede retirar la cantidad de " + retirar.text + " pesos";
				msg_error.color = new Color32(255,0,0,100);
				retirar.text ="";
				return;
			}
			
		
		//Debug.Log("El balance es : " + balance.text + "Y la cantidad ingresada es de : " + retirar.text + ", y el resultado de esta acción es de : " + resultado_interno);

	
	}

	void CerrarSesion(){
		ActivarScreen(LoginScreen);
		if (!recordar.isOn)
		{
			DNI.text="";
			password.text="";
		}
	}
	
	void NavegarHistorial(){
		ActivarScreen(TranssactionScreen);
	}
	
	
	void NavegarMainScreen(){
		ActivarScreen(MainScreen);
	}
	
}