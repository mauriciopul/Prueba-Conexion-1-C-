﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PruebaConexion1
{
    class Conection
    {
        SqlConnection cn = new SqlConnection("Data Source=.; Initial Catalog=PruebaConexion1; Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader dr;

        SqlDataAdapter da;
        DataTable dt;

        public Conection()
        {
            cn.Open();
            MessageBox.Show("Conexion creada");
        }

        public string insertar(int id, string nom, string apell, string fechaNac)
        {
            string salida = "Se inserto el usuairo exitosamente";
            try
            {
                cmd = new SqlCommand(
                    "insert into Personas(Id, Nombre, Apellidos, FechaNacimiento) " +
                    "values(" + id + ", '" + nom + "', '" + apell + "', '" + fechaNac + "')", cn
                    );
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                salida = "Error al insertar usuario: " + ex.ToString();
            }
            return salida;
        }

        public int validar(int id)
        {
            int cont = 0;
            try
            {
                cmd = new SqlCommand(
                    "select * from Personas where id = " + id + "", cn
                    );
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cont++;
                }
                dr.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al validar el ID: " + ex.ToString());
            }
            return cont;
        }

        public void mostrarDatos(DataGridView dgv)
        {
            try
            {
                da = new SqlDataAdapter("select * from personas", cn);
                dt = new DataTable();
                da.Fill(dt);
                dgv.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mostrar Data: " + ex.ToString());
            }
        }

        public string eliminar(int id)
        {
            string salida;
            try
            {
                cmd = new SqlCommand(
                    "delete from Personas where id = " + id + "", cn
                    );
                cmd.ExecuteNonQuery();
                salida = "Se eliminó con exito el usuario";
            }
            catch (Exception ex)
            {
                salida = "Error al eliminar usuario: " + ex.ToString();
            }
            return salida;
        }

        public string modificar(int id, string nomb, string apell, string fechaNac)
        {
            string salida = "Usuario modificado exitosamente";
            try
            {
                cmd = new SqlCommand(
                    "update Personas set Nombre = '" + nomb + "', Apellidos = '" + apell + "', FechaNacimiento = '" + fechaNac + "' " +
                    "where id = "+id+""
                    , cn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                salida = "Error al modificar usuario: " + ex.ToString();
            }
            return salida;
        }
        public string buscar(int id, string nom, string apell, string fechaN)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar: "+ ex.ToString());
            }

        }


    }
}
