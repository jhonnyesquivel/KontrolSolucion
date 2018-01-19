<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JETable.ascx.cs"
    Inherits="Kontrol.Web.UserControls.JETable" %>

<div class="box-body">
    <table id="tabla_control" runat="server">
    </table>
</div>

<script>
    $(document).ready(function () {

        $('table[name=<%= IdTabla%>]').DataTable({
            "paging": <%= Paging.ToString().ToLower() %>,
            "lengthChange": <%= LengthChange.ToString().ToLower() %>,
            "searching": <%= Searching.ToString().ToLower() %>,
            "ordering": <%= Ordering.ToString().ToLower() %>,
            "info": <%= Info.ToString().ToLower() %>,
            "autoWidth": <%= AutoWidth.ToString().ToLower() %>,
            columns: <%=DataColumnas%>,
            data: <%= JavaScriptSource %>
        });
    });

    
</script>

