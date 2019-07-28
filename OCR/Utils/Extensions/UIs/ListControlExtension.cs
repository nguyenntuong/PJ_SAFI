using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OCR.Utils.Extensions.UIs
{
    public static class ListControlExtension
    {
        /// <summary>
        /// Cập nhật danh sách cho các Control kế thừa ListControl
        /// Chức năng chính là cập nhật UI khi Source thay đổi, hay các phần
        /// tử trong source đã thay đổi nộ dung nhưng UI không thay đổi
        /// </summary>
        /// <param name="lstControl">control kế thừa từ ListControl</param>
        /// <param name="dataSource">dataSource phải kế thừa từ IEnumerable<object></param>
        /// <param name="selectedItem">Item được chọn khi Update, sẽ kích hoạt sự kiện SelectItemChange</param>
        public static void UpdateUI(this ListControl lstControl, IEnumerable<object> dataSource = null, object selectedItem = null)
        {
            if (dataSource == null || (dataSource != null && dataSource.Count() == 0))
            {
                dataSource = dataSource ?? new List<object>();
                selectedItem = null;
            }
            switch (lstControl)
            {
                case ListBox control:
                    control.Items.Clear();
                    control.Items.AddRange(dataSource.ToArray());
                    control.SelectedItem = selectedItem;
                    break;
                case ComboBox control:
                    control.Items.Clear();
                    control.Items.AddRange(dataSource.ToArray());
                    control.SelectedItem = selectedItem;
                    break;
                default:
                    break;
            }
        }

    }
}
