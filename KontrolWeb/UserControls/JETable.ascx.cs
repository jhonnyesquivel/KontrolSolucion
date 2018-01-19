using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using static System.Net.Mime.MediaTypeNames;

namespace Kontrol.Web.UserControls
{
    [DefaultProperty("Columnas"),
    ParseChildren(true, "Columnas"), PersistChildren(false),
    ToolboxData("<{0}:JETable runat=\"server\"> </{0}:JETable>")]
    public partial class JETable : System.Web.UI.UserControl
    {

        public int prueba = 0;
        public bool Paging { get; set; }
        public bool LengthChange { get; set; }
        public bool Searching { get; set; }
        public bool Ordering { get; set; }
        public bool Info { get; set; }
        public bool AutoWidth { get; set; }
        public string IdTabla { get; set; }
        public string IdContentScript { get; set; }
        public string CssClass { get; set; }
        public string DataColumnas
        {

            get
            {
                string retorno = "[";

                foreach (JEColumn jecol in Columnas)
                {
                    string item = string.Empty;
                    switch (jecol.TypeColumn)
                    {
                        case JEColumn.Type.Key:
                            item = "{title: \"" + jecol.HeaderText + "\", visible: " + (!jecol.Hidden).ToString().ToLower() + "," +
                                "data: \"" + (string.IsNullOrEmpty(jecol.DataField) ? "null" : jecol.DataField) + "\"},";
                            retorno += item;
                            break;
                        case JEColumn.Type.Text:
                            item = "{title: \"" + jecol.HeaderText + "\", visible: " + (!jecol.Hidden).ToString().ToLower() + ", data: \"" + (string.IsNullOrEmpty(jecol.DataField) ? "null" : jecol.DataField) + "\"},";

                            retorno += item;
                            break;
                        case JEColumn.Type.Edit:
                            item = "{ searchable: false, sortable: false, data:\"" + (string.IsNullOrEmpty(jecol.DataField) ? "null" : jecol.DataField) + "\", \"render\": function( data, type, full, meta) {" +
                                    "var buttonID = \"edit_\" + data;" +
                                    "return '<a id=\"' + buttonID + '\" class=\"fa fa-edit btn btn-primary\" role=\"button\" onclick=\"" + jecol.onClientEditEvent + "('+data+')\"></a>'; }},";

                            retorno += item;
                            break;
                        case JEColumn.Type.Delete:

                            item = "{ searchable: false, sortable: false, data:\"" + (string.IsNullOrEmpty(jecol.DataField) ? "null" : jecol.DataField)+"\", \"render\": function( data, type, full, meta) {" +
                                    "var buttonID = \"delete_\" + data;" +
                                    "return '<a id=\"' + buttonID + '\" class=\"fa fa-trash btn btn-danger\" role=\"button\" onclick=\"" + jecol.onClientEditEvent + "('+data+')\"></a>'; }},";
                            
                            retorno += item;
                            break;
                        case JEColumn.Type.Money:
                            item = "{title: \"" + jecol.HeaderText + "\", visible: " + (!jecol.Hidden).ToString().ToLower() + "," +
                                     "data: \"" + (string.IsNullOrEmpty(jecol.DataField) ? "null" : jecol.DataField) +
                                 "\", render: $.fn.dataTable.render.number( ',', '.', 0, '$' )},";
                            break;
                        default:
                            break;
                    }
                }

                retorno = retorno.TrimEnd(',') + "]";
                return retorno;
            }
        }


        public DataTable DataTableSource { get; set; }

        private object _ObjectDataSource = string.Empty;
        public object DataSource
        {
            get
            {
                return _ObjectDataSource;

            }
            set
            {
                _ObjectDataSource = value;

            }
        }

        public string JavaScriptSource
        {
            get
            {
                JavaScriptSerializer serializer = new JavaScriptSerializer();

                //return serializer.Serialize(ConvertTable(DataTableSource));
                return serializer.Serialize(_ObjectDataSource);
            }
        }

        static List<string[]> ConvertTable(DataTable table)
        {
            return table.Rows.Cast<DataRow>()
               .Select(row => table.Columns.Cast<DataColumn>()
                  .Select(col => Convert.ToString(row[col]))
               .ToArray())
            .ToList();
        }

        private List<JEColumn> _columnas = new List<JEColumn>();

        [Category("Behavior"), Description("The fields collection"),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Content),
        PersistenceMode(PersistenceMode.InnerDefaultProperty),
        DefaultValue(null), MergableProperty(false), Bindable(false)]
        public List<JEColumn> Columnas
        {
            set { _columnas = value; }
            get
            {
                if (_columnas == null)
                {
                    _columnas = new List<JEColumn>();
                }
                return _columnas;
            }
        }

        protected override void AddParsedSubObject(object obj)
        {
            base.AddParsedSubObject(obj);


            if (obj is JEColumn)
            {
                this.Columnas.Add((JEColumn)obj);
                return;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            tabla_control.Attributes["name"] = IdTabla;
            tabla_control.Attributes["class"] = CssClass;
            this.DataBind();
        }


    }

    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class JEColumn
    {
        public string HeaderText { get; set; }
        public string DataField { get; set; }
        public enum Type : byte { Key = 1, Text = 2, Edit = 3, Delete = 4, Money = 5 }; //Key, Text, Edit, Edit, Delet
        public Type TypeColumn { get; set; }
        public bool Hidden { get; set; }
        public string onClientEditEvent { get; set; }
        public string onClientDeleteEvent { get; set; }


    }
}