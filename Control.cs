using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    class Control
    {
        public ListBox console { get; set; }
        public ComboBox accountComboBox { get; set; }
        public Dao dao { get; set; }

        public DataGridView itemGridView;

        public TextBox codeTextBox;
        public CheckBox targetCheckBox;

        public List<Item> itemList;

        public void Print(string message)
        {
            Print(message, null);
        }

        public void Print(string message, string code)
        {
            if (this.console != null)
            {
                StringBuilder sb = new StringBuilder(DateTime.Now.ToString());
                sb.Append(code != null ? " [" + code + "] " : " ");
                sb.Append(message);
                this.console.Items.Add(sb.ToString());

            }
            else
            {
                Console.WriteLine(message);
            }
        }

        int mode;
        public void RealtimeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb.Checked)
            {
                mode = Constants.MODE_REALTIME;
                Print("Realtime Mode");
            }
        }

        public void SimulateRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb.Checked)
            {
                mode = Constants.MODE_SIMULATE;
                Print("Simulate Mode");
            }
        }

        public Boolean IsRealtimeMode()
        {
            return Constants.MODE_REALTIME == mode;
        }
        public Boolean IsSimulateMode()
        {
            return Constants.MODE_SIMULATE == mode;
        }

        public void ItemGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var sendGrid = (DataGridView)sender;
            if (sendGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                if (this.itemGridView.Rows[e.RowIndex].Cells[2].Value != null)
                {
                    string targetValue = this.itemGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
                    Item entity = itemList[e.RowIndex];
                    entity.target = targetValue;
                    dao.InsertItemData(entity);
                    Print("Updated item data with target = " + targetValue, entity.code);
                    InquireButtonClick(null, null);
                }
            }
        }

        public void InquireButtonClick(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(codeTextBox.Text))
            {
                itemList = dao.GetItemData(codeTextBox.Text, false);
                itemGridView.DataSource = itemList;
                Print("Refresh ItemGridView");
            }
            else if (targetCheckBox.Checked == true)
            {
                itemList = dao.GetItemData(null, true);
                itemGridView.DataSource = itemList;
                Print("Refresh ItemGridView");
            }

            // TODO 새코드정보를 어떻게 등록할 것인지를 생각할것
        }

        public string GetCode()
        {
            return codeTextBox.Text;
        }
    }
}
