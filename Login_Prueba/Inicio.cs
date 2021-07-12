using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Login_Prueba
{
    [Activity(Label = "Inicio")]
    public class Inicio : Activity
    {
        Base_Datos conex = new Base_Datos();

        protected override void OnCreate(Bundle savedInstanceState)
        {
           base.OnCreate(savedInstanceState);

           // Create your application here
           SetContentView(Resource.Layout.Inicio);

           var txtCategoria = FindViewById<EditText>(Resource.Id.edt_Cat);
            var txtNombre = FindViewById<EditText>(Resource.Id.edt_Pro);
            var txtPrecio = FindViewById<EditText>(Resource.Id.edt_Precio);

            var btnRegistrar = FindViewById<Button>(Resource.Id.btn_Registrar);

            btnRegistrar.Click += delegate
            {
                conex.IngresarProducto(txtCategoria.Text, txtNombre.Text, Convert.ToDouble(txtPrecio.Text));
                //if (conex.IngresarProducto(txtCategoria.Text, txtNombre.Text, Convert.ToDouble(txtPrecio.Text)))
                //{
                //    Toast.MakeText(this, "Producto Registrado Correctamente", ToastLength.Short).Show();
                //    //Habilitar una nueva vista
                //    Intent intent = new Intent(this, typeof(Inicio));
                //    StartActivity(intent);

                //    //StartActivity(Intent.CreateChooser(correo, "Mensaje Enviado"));
                //}
                //else if (conex.IngresarProducto(txtCategoria.Text, txtNombre.Text, Convert.ToDouble(txtPrecio.Text)))
                //{
                //    //Muestra mensaje en pantalla
                //    Toast.MakeText(this, "Campos Vacios/Producto no se pudo registrar", ToastLength.Short).Show();
                //    //Limpia los campos
                //    txtCategoria.Text = "";
                //    txtNombre.Text = "";
                //    txtPrecio.Text = "";

                //}

            };
        }
    }

}