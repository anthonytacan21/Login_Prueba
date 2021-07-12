using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
    public class Base_Datos
    {
        static string url = "Data Source=192.168.7.107;Initial Catalog=CuartoBRestaurant;User ID=sa;Password=101199";

        int valor = 0;

        SqlConnection con = new SqlConnection(url);
      
        public int Ingresar(string usuario, string contra)
        {
            string consulta = "Select lgn_usuario,lgn_contraseña,lgn_id from tbl_login where lgn_usuario ='"+usuario+"' and lgn_contraseña='"+contra+"'";

            valor = 0;

            con.Open();

            SqlCommand comand = new SqlCommand(consulta,con);

            SqlDataReader rs = comand.ExecuteReader();
            
            while (rs.Read())
            {
                if(rs["lgn_usuario"].ToString().Equals(usuario)&& rs["lgn_contraseña"].ToString().Equals(contra))
                {
                    if(rs["lgn_id"].ToString().Equals("1"))
                    {
                        valor = 1;
                    }

                    if (rs["lgn_id"].ToString().Equals("2"))
                    {
                        valor = 2;
                    }

                    if (rs["lgn_id"].ToString().Equals("3"))
                    {
                        valor = 3;
                    }
                }
                else
                {
                    valor = 0;
                }
            }
            rs.Close();
            con.Close();
            return valor;


        }

        public void IngresarProducto(string categoria, string nombre, double precio)
        {
            string consulta = "INSERT INTO tbl_producto(pro_categoria,pro_nombre,pro_precio) VALUES (@C,@N,@P)";

            con.Open();

            SqlCommand command = new SqlCommand(consulta, con);

            command.Parameters.Add("@C", SqlDbType.VarChar, 30).Value = categoria;

            command.Parameters.Add("@N", SqlDbType.VarChar, 30).Value = nombre;

            command.Parameters.Add("@P", SqlDbType.Float, 30).Value = precio;

            command.CommandType = CommandType.Text;

            command.ExecuteReader();

            con.Close();
        }
    }
}