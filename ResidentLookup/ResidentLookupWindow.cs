using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using IronXL;
using Newtonsoft.Json.Linq;

namespace ResidentLookup
{
    public partial class ResidentLookupWindow : Form
    {
        DataTable Residents;
        public ResidentLookupWindow()
        {
            string dataSource = ConfigurationManager.AppSettings["DataSource"];

            InitializeComponent();

            //Find the data file in the config and process it based on the type. If the datatype is not valid display message to the user.
            if (dataSource.Substring(dataSource.LastIndexOf(".")) == ".xml")
                Residents = GetXMLDataFile(ConfigurationManager.AppSettings["DataSource"]);
            else if (dataSource.Substring(dataSource.LastIndexOf(".")) == ".csv")
                Residents = GetCSVDataFile(ConfigurationManager.AppSettings["DataSource"]);
            else
                UserMessageLabel.Text = "Unable to load a data file. Please check config and make sure you are using either a .xml or .csv file.";
        }

        /// <summary>
        /// Event to stop characters besides numbers entered into StreetNumberTextbox_
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StreetNumberTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Checks whether the key pressed is not a number or control character(backspace) and ends the event if it isnt.
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// The method used for filtering the dataset and displaying it on the screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchButton_Click(object sender, System.EventArgs e)
        {
            //If the data is not loaded do nothing.
            if (Residents != null)
            {
                //Clear the previous data
                ResidenceDataGrid.DataSource = null;

                //Query on our stored data table with the users input.
                var queryResults = Residents.AsEnumerable()
                                            .Where(row => row.Field<string>("StreetName").ToLower().Contains(StreetNameTextbox.Text.ToLower())
                                                        && row.Field<string>("HouseNumber") == StreetNumberTextbox.Text)
                                            .OrderByDescending(row => row.Field<string>("Age"));

                //Check whether the query results are null or 0 the either display the data and/or a message to the user.
                if ((queryResults?.Count() ?? 0) != 0)
                {
                    UserMessageLabel.Text = "See your results below. Thank you for searching. ";
                    ResidenceDataGrid.DataSource = queryResults.CopyToDataTable();
                }
                else
                    UserMessageLabel.Text = "No results were returned. Please search again.";
            }
        }

        /// <summary>
        /// Method used to get data from the XML file. Only returns first DataTable.
        /// </summary>
        /// <param name="pathname"></param>
        /// <returns></returns>
        private DataTable GetXMLDataFile(string pathname)
        {
            //Initialise the dataset class used to parse the XML in to
            DataSet dataSetFromXML = new DataSet();
            //Initialise the dataTable class which will be returned 
            DataTable returnDataTable = new DataTable();
            //Initialise the DataRow to be used to later to add rows to the table.
            DataRow convertedRow;

            //use the DataSet class's method to read the XML file
            dataSetFromXML.ReadXml(pathname);

            //Loop through all of the rows in the first table. Only accepts 1 table.
            foreach(DataRow row in dataSetFromXML.Tables[0].Rows)
            {
                //convert the text in each record to be a JObect to make it easier to manipulate.
                JObject convertedAddressRecordJSON = JObject.Parse("{" + row.ItemArray[0].ToString().Replace('=', ':').Replace("\"\r\n", "\",") + "}");

                //Check if this is the first row being added and if it is loop through and add the columns to the dataTable
                if (returnDataTable.Rows.Count == 0)
                    foreach (var keyValue in convertedAddressRecordJSON)
                        returnDataTable.Columns.Add(keyValue.Key);

                //Initialise the DataRow to be added to the table.
                convertedRow = returnDataTable.NewRow();
                
                //Loop through the JObject adding the values to the DataRow based on key value pairs
                foreach (var keyValue in convertedAddressRecordJSON)
                    convertedRow[keyValue.Key] = keyValue.Value;
                
                //Add the DataRow to the DataTable
                returnDataTable.Rows.Add(convertedRow);
            }
            //Return the datatable.
            return returnDataTable;
        }

        /// <summary>
        /// Method used to get data from the CSV file. Only returns first worksheet.
        /// </summary>
        /// <param name="pathname"></param>
        /// <returns></returns>
        private DataTable GetCSVDataFile(string pathname)
        {
            //Load the CSV into a worbook using a method in the WorkBook class from the IronXL NuGet package.
            WorkBook workbook = WorkBook.LoadCSV(pathname, fileFormat: ExcelFileFormat.XLSX, ",");
            //Add the first worksheet as a DataTable using the method from the ToDataTable method from the WorkSheet class in IronXL.
            DataTable residents = new DataTable();

            foreach (var col in workbook.DefaultWorkSheet.Columns)
            {
                //Convert the column names to remove spaces to match the xml file.
                col.Rows[0].StringValue = col.Rows[0].ToString().Replace(" ", string.Empty);
                //Added columns in manuall to force them to be string values to avoid casting issues.
                residents.Columns.Add(col.Rows[0].ToString().Replace(" ", string.Empty), typeof(string));
            }

            //Loads the workbook datatable into the already created residents datatable. Keeps already created columns
            residents.Load(workbook.DefaultWorkSheet.ToDataTable(true).CreateDataReader(), LoadOption.OverwriteChanges);
           
            //Return the results
            return residents;
        }
    }
}
