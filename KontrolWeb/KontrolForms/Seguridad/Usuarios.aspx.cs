using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Kontrol.Datos.Seguridad;
using Kontrol.Negocio;
using System.Data;
using Kontrol.Utilidades;
using System.Web.Script.Serialization;

namespace Kontrol.Web.KontrolForms.Seguridad
{
    public partial class Usuarios : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Crud evento = Crud.consultar;
                int id = 0;

                if (Page.RouteData.Values["evento"] != null)
                {

                    evento = Enumeradores.ParseEnum<Crud>(Page.RouteData.Values["evento"].ToString(), Crud.error);
                    id = int.Parse(Page.RouteData.Values["id"].ToString());
                    ProcesoNegocio pn = new ProcesoNegocio();
                    List<SegUsuarios> resultado = null;
                    switch (evento)
                    {
                        case Crud.consultar:
                            resultado = pn.SeleccionarUsuarios(id);
                            break;
                        case Crud.insertar:
                            //pn.InsertarUsuario();
                            break;
                        case Crud.actualizar:
                            break;
                        case Crud.eliminar:
                            break;
                        case Crud.jsconsultar:
                            resultado = pn.SeleccionarUsuarios(id);
                            JavaScriptSerializer serializer = new JavaScriptSerializer();
                            string strRespuesta = serializer.Serialize(resultado);
                            WriteAndEndResponse(strRespuesta);                            
                            break;
                        default:
                            resultado = pn.SeleccionarUsuarios(0);
                            break;
                    }

                    JETable.DataSource = resultado;


                }
            }
        }

        private void WriteAndEndResponse(string response)
        {
            Response.Clear();
            Response.ContentType = "application/json; charset=utf-8";
            Response.Write(response);
            Response.End();
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            SegUsuarios usuario = new SegUsuarios()
            {
                PrimerNombre = txtPrimerNombre.Text.Trim(),
                SegundoNombre = txtSegundoNombre.Text.Trim(),
                PrimerApellido = txtPrimerApellido.Text.Trim(),
                SegundoApellido = txtSegundoApellido.Text.Trim(),
                Username = txtUsername.Text.Trim(),
                Password = txtPassword.Text.Trim(),
                FechaActualizacionRegistro = DateTime.Now,
                FechaCreacionRegistro = DateTime.Now
            };

            ProcesoNegocio pn = new ProcesoNegocio();
            int a = pn.InsertarUsuario(usuario);



        }

    }
}