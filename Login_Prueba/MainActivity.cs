using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Content;

namespace Login_Prueba
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        Base_Datos conex = new Base_Datos();
        int cont = 1;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            var edt_Usuario = FindViewById<EditText>(Resource.Id.edt_Usuario);

            var edt_Contraseña = FindViewById<EditText>(Resource.Id.edt_Contraseña);

            var btn_Ingresar = FindViewById<Button>(Resource.Id.btn_Ingresar );

            var btn_Registrar = FindViewById<Button>(Resource.Id.btn_Registrar);

            var intento = FindViewById<TextView>(Resource.Id.txt_Intento);

            intento.Text = "0";

            btn_Ingresar.Click += delegate
            {
                //generacion de un intent  para enviar correo
                //Intent correo = new Intent(Intent.ActionSendMultiple);
                //correo.PutExtra(Intent.ExtraEmail, new string[] { "elkinjparedes12@gmail.com" });
                //correo.PutExtra(Intent.ExtraSubject, "Comprobante de Ingreso");
                //correo.PutExtra(Intent.ExtraText, "La empresa Fabritext le desea que este teniendo una excelente jornada");
                //correo.SetType("message/rfc822");


                //string Usuario1 = "Javier", pass = "1234";
                //conex.Conectar();

                if (conex.Ingresar(edt_Usuario.Text, edt_Contraseña.Text) == 1)
                {
                    Toast.MakeText(this, "Bienvenido al Sistema", ToastLength.Short).Show();
                    //Habilitar una nueva vista
                    Intent intent = new Intent(this, typeof(Inicio));
                    StartActivity(intent);

                    //StartActivity(Intent.CreateChooser(correo, "Mensaje Enviado"));
                }
                else if (conex.Ingresar(edt_Usuario.Text, edt_Contraseña.Text) != 1)
                {
                    //Muestra mensaje en pantalla
                    Toast.MakeText(this, "Usuario o Contraseña Invalidos", ToastLength.Short).Show();
                    //Hace el conteo y bloquea el boton
                    intento.Text = cont.ToString();
                    cont++;
                    if (intento.Text == "3")
                    {
                        // Muestra un mensaje en pantalla
                        Toast.MakeText(this, "Maximo de intentos alcanzado usuario bloqueado", ToastLength.Short).Show();
                        btn_Ingresar.Enabled = false;
                        //Cierra el programa
                        Finish();
                    }
                    //Limpia los campos
                    edt_Usuario.Text = "";
                    edt_Contraseña.Text = "";

                }
            };

            btn_Registrar.Click += delegate
            {
                Intent intent = new Intent(this, typeof(Registrar));
                StartActivity(intent);
                
            };


        }
    }
}