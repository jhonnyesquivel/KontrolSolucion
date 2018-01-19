<%@ Page Title="" Language="C#" MasterPageFile="~/KontrolForms/Master/MasterPrivado.master" AutoEventWireup="true"
    CodeBehind="Usuarios.aspx.cs" Inherits="Kontrol.Web.KontrolForms.Seguridad.Usuarios" EnableEventValidation="false" %>

<%@ MasterType VirtualPath="~/KontrolForms/Master/MasterPrivado.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="estilos" runat="server">

    <script>

        window.onload = load()

        function load() {
            var script = document.getElementById('div-script-uc');

            if (script)//checking whether it is found on DOM, but not necessary
            {
                console.log(script);
                script.innerHTML = "<script>" + document.getElementById('div_script').innerHTML + "<\/script>";
                console.log(script);
            }
        }


    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" runat="server">
    <div class="row">
        <div class="col-sm-10">
            <a class="btn btn-lg btn-primary" onclick="$('#modal_usuario').modal('show')">
                <i class="fa fa-plus"></i>
                Nuevo Usuario
            </a>
        </div>
    </div>
    <div class="row">
        <div class="col-xs-12">
            <div class="box">
                <div class="box-header">
                    <h3 class="box-title">Usuarios Registrados</h3>
                </div>
                <%--          <input type="button" id="asd" onclick="$('table[name=example').DataTable().ajax.reload();"/>--%>
                <J:JETable runat="server" ID="JETable" IdTabla="example"
                    IdContentScript="div-script-uc"
                    CssClass="table table-bordered table-hover"
                    AutoWidth="true"
                    LengthChange="true"
                    Ordering="true"
                    Searching="true"
                    Paging="true">
                    <J:JEColumn DataField="IdUsuario" HeaderText="ID" TypeColumn="Key" Hidden="false" />
                    <J:JEColumn DataField="PrimerApellido" HeaderText="PRIMER APELLIDO" TypeColumn="Text" />
                    <J:JEColumn DataField="SegundoApellido" HeaderText="SEGUNDO APELLIDO" TypeColumn="Text" />
                    <J:JEColumn DataField="PrimerNombre" HeaderText="PRIMER NOMBRE" TypeColumn="Text" />
                    <J:JEColumn DataField="SegundoNombre" HeaderText="SEGUNDO NOMBRE" TypeColumn="Text" />
                    <J:JEColumn HeaderText="Editar" DataField="IdUsuario" TypeColumn="Edit" onClientEditEvent="EditarUsuario" />
                    <J:JEColumn HeaderText="Eliminar" DataField="IdUsuario" TypeColumn="Delete" onClientDeleteEvent="EliminarUsuario" />
                </J:JETable>
            </div>

        </div>
    </div>
    <div class="modal" id="modal_usuario">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">×</span></button>
                    <h4 class="modal-title">Información del Usuario</h4>
                </div>

                <div class="modal-body">
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-horizontal">
                                <div class="form-group">
                                    <label for="txtPrimerNombre" class="col-sm-4 control-label">Primer Nombre</label>
                                    <div class="col-sm-7">
                                        <asp:TextBox ID="txtPrimerNombre" runat="server" placeholder="Primer Nombre" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="txtSegundoNombre" class="col-sm-4 control-label">Segundo Nombre</label>
                                    <div class="col-sm-7">
                                        <asp:TextBox ID="txtSegundoNombre" runat="server" placeholder="Segundo Nombre" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="txtPrimerApellido" class="col-sm-4 control-label">Primer Apellido</label>
                                    <div class="col-sm-7">
                                        <asp:TextBox ID="txtPrimerApellido" runat="server" placeholder="Primer Apellido" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="txtSegundoApellido" class="col-sm-4 control-label">Segundo Apellido</label>
                                    <div class="col-sm-7">
                                        <asp:TextBox ID="txtSegundoApellido" runat="server" placeholder="Segundo Apellido" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="col-md-6">
                            <div class="form-horizontal">

                                <div class="form-group">
                                    <label for="txtUsername" class="col-sm-4 control-label">Nombre de Usuario</label>
                                    <div class="col-sm-7">
                                        <asp:TextBox ID="txtUsername" runat="server" placeholder="Usuario" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="txtPassword" class="col-sm-4 control-label">Contraseña</label>
                                    <div class="col-sm-7">
                                        <asp:TextBox ID="txtPassword" runat="server" placeholder="Contraseña" TextMode="Password" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>
                </div>

                <div class="modal-footer">
                    <input type="reset" data-dismiss="modal" class="btn btn-default btn-lg" value="Cancelar" onclick="cancelarEdicion()" />
                    <asp:Button ID="btnGuardar" CssClass="btn btn-lg btn-primary " runat="server" OnClick="btnGuardar_Click" Text="Guardar" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="privada_scripts" runat="server">
    <script type="text/javascript">
        function EditarUsuario(IdUsuario) {

            $.ajax({
                type: "POST",
                url: "<%= GetRouteUrl("usuarios", new { evento = "jsconsultar"}) %>/" + IdUsuario,
                success: function (response) {
                    var usuario = response[0];

                    $("#<%=txtPrimerNombre.ClientID%>").val(usuario.PrimerNombre);
                    $("#<%=txtSegundoNombre.ClientID%>").val(usuario.SegundoNombre);
                    $("#<%=txtPrimerApellido.ClientID%>").val(usuario.PrimerApellido);
                    $("#<%=txtSegundoApellido.ClientID%>").val(usuario.SegundoApellido);
                    $("#<%=txtUsername.ClientID%>").prop("disabled", true);
                    $("#<%=txtPassword.ClientID%>").prop("disabled", true);
                    $('#modal_usuario').modal('show');
                    $("#<%=txtPrimerNombre.ClientID%>").focus();
                },
                failure: function (msg) {
                    console.log(msg);
                }
            });

        }

        function EliminarUsuario(IdUsuario) {


        }

        function cancelarEdicion() {
            $('#modal_usuario').modal('hide');
        }

    </script>
</asp:Content>
